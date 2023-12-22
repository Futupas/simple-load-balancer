var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string FILE_PATH = "requestsCount.txt";
var requestsCount = 0;

app.MapGet("/", () =>
{
    requestsCount++;
    File.WriteAllText(FILE_PATH, requestsCount.ToString());
    return "Hello World!";
});

app.MapGet("/count", () => requestsCount);

app.Run();
