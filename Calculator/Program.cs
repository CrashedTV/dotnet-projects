using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<ICalculatorService, CalculatorService>();


services.AddSingleton<ICalculationHistoryRepository>(serviceProvider =>
{
    var dataDirectory = Path.Combine(AppContext.BaseDirectory, "Data");
    Directory.CreateDirectory(dataDirectory);

    var filePath = Path.Combine(dataDirectory, "calculation-history.json");
    return new JsonCalculationHistoryRepository(filePath);
});

services.AddSingleton<ICalculatorApp, CalculatorApp>();

using var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<ICalculatorApp>();

app.Run();
