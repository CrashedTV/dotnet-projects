public interface ICalculationHistoryRepository
{
	void Save(CalculationRecord record);
	List<CalculationRecord> GetCalculationHistory();
	void ClearHistory();
	void Undo();
}