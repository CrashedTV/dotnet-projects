public class CalculatorApp : ICalculatorApp
{
    private readonly ICalculatorService _calculatorService;
    private readonly ICalculationHistoryRepository _historyRepository;

    public CalculatorApp(ICalculatorService calculatorService, ICalculationHistoryRepository historyRepository)
    {
        _calculatorService = calculatorService;
        _historyRepository = historyRepository;
    }

    public void Run()
    {
        Console.Clear();
        var shouldContinue = true;
        while (shouldContinue)
        {
            ShowMenu();

            int choice = (int)InputHelper.GetInput("Select an option: ");


            switch (choice) 
            {
                case (int)CalculatorOption.Exit:
                    shouldContinue = false;
                    break;
                case (int)CalculatorOption.Add:
                    RunCalculation(choice);
                    break;
                case (int)CalculatorOption.Subtract:
                    RunCalculation(choice);
                    break;
                case (int)CalculatorOption.Multiply:
                    RunCalculation(choice);
                    break;
                case (int)CalculatorOption.Divide:
                    RunCalculation(choice);
                    break;
                case (int)CalculatorOption.ShowHistory:
                    ShowHistory();
                    break;
                case (int)CalculatorOption.Undo:
                    _historyRepository.Undo();
                    break;

                case (int)CalculatorOption.ClearHistory:
                    ClearHistory();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    private void ShowMenu()
    {
        Console.WriteLine("============================");
        Console.WriteLine("||     Calculator App     ||");
        Console.WriteLine("============================");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. Show History");
        Console.WriteLine("6. Undo Last Operation");
        Console.WriteLine("7. Clear History");
    }


    private void ShowHistory()
    {
        var history = _historyRepository.GetCalculationHistory();
        if (history.Count == 0)
        {
            Console.WriteLine("No calculations yet.");
            return;
        }
        Console.WriteLine("Calculation History:");
        foreach (var record in history)
        {
            Console.WriteLine($"{record.Expression} = {record.Result:F2} | {record.Timestamp}");
        }
    }
    private void ClearHistory()
    {
        _historyRepository.ClearHistory();
        Console.WriteLine("Calculation history cleared.");
    }

    private void RunCalculation(int choice)
    {
        double firstNumber = InputHelper.GetInput("Enter first number: ");
        double secondNumber = InputHelper.GetInput("Enter second number: ");
        double result = 0;
        string symbol = "";
        switch (choice)
        {
            case (int)CalculatorOption.Add:
                result = _calculatorService.Add(firstNumber, secondNumber);
                symbol = "+";
                break;
            case (int)CalculatorOption.Subtract:
                result = _calculatorService.Subtract(firstNumber, secondNumber);
                symbol = "-";
                break;
            case (int)CalculatorOption.Multiply:
                result = _calculatorService.Multiply(firstNumber, secondNumber);
                symbol = "*";
                break;
            case (int)CalculatorOption.Divide:
                try {
                    result = _calculatorService.Divide(firstNumber, secondNumber);
                    symbol = "/";
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                break;
        }
        Console.Write($"{firstNumber} {symbol} {secondNumber} = {result:F2}\n");
        _historyRepository.Save(new CalculationRecord
        {
            Expression = $"{firstNumber} {symbol} {secondNumber}",
            Result = result,
            Timestamp = DateTime.Now
        });
    }
}