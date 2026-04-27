using System.Text.Json;
public class JsonCalculationHistoryRepository : ICalculationHistoryRepository {
    private readonly string _filePath;
    public JsonCalculationHistoryRepository(string filePath)
    {
        _filePath = filePath;
    }


    private List<CalculationRecord> _history = new List<CalculationRecord>();
    public void Save(CalculationRecord record)
    {
        _history.Add(record);
        var json = JsonSerializer.Serialize(_history);
        File.WriteAllText(_filePath, json);
    }

    public List<CalculationRecord> GetCalculationHistory()
    {
        if (!File.Exists(_filePath))
            return [];

        var json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
            return [];
        

        return JsonSerializer.Deserialize<List<CalculationRecord>>(json) ?? [];
    }

    public void ClearHistory()
    {
        File.WriteAllText(_filePath, "[]");
    }

    public void Undo()
    {
        var history = GetCalculationHistory();
        if (history.Count > 0)
        {
            Console.WriteLine($"Undoing: {history.Last().Expression}");
            history.RemoveAt(history.Count - 1);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(history));
        }
        else
            Console.WriteLine("No operations to undo.");
    }

}