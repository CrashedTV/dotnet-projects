using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IBookService, BookService>();
services.AddSingleton<IBorrowService, BorrowService>();
services.AddSingleton<IMemberService, MemberService>();
services.AddSingleton<IReportService, ReportService>();

#region Repository Registrations
services.AddSingleton<IBookRepository, BookRepository>();
services.AddSingleton<IMemberRepository, MemberRepository>();
services.AddSingleton<IBorrowRepository, BorrowRepository>();
#endregion

services.AddSingleton<IMainApplication, MainApplication>();

using var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IMainApplication>();

app.Run();


