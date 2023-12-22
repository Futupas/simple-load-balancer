using System;
using System.Net.Http;
using System.Threading.Tasks;

Console.WriteLine("Hello, World!");

const string baseUrl = "http://192.168.0.100:1234/";
const int numberOfRequests = 10000;

await MakeRequestsAsync(baseUrl, numberOfRequests);

Console.WriteLine("All requests completed.");

static async Task MakeRequestsAsync(string baseUrl, int numberOfRequests)
{
    var httpClient = new HttpClient();

    // Create an array of tasks for making asynchronous requests
    var requestTasks = new Task[numberOfRequests];

    for (int i = 0; i < numberOfRequests; i++)
    {
        // Make an asynchronous request and store the task in the array
        requestTasks[i] = MakeRequestAsync(httpClient, $"{baseUrl}/{i + 1}");
    }

    // Wait for all tasks to complete
    await Task.WhenAll(requestTasks);
}

static async Task MakeRequestAsync(HttpClient httpClient, string url)
{
    try
    {
        HttpResponseMessage response = await httpClient.GetAsync(url);
        Console.WriteLine($"Request to {url} completed with status code: {response.StatusCode}");
        // You can also process the response content here if needed
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Request to {url} failed with error: {ex.Message}");
    }
}





