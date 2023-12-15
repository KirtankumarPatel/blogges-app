using System;
using RestSharp;

class BlogApi
{
    static void Main()
    {
        string apiUrl = "https://newsapi.org/v2/top-headlines?sources=bbc-news&apiKey=553ca5ab0506413cba32c79a3ad6e10f";
        // Create RestClient
        var client = new RestClient(apiUrl);

        var request = new RestRequest(Method.GET);

        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);

            var todo = Newtonsoft.Json.JsonConvert.DeserializeObject<Todo>(response.Content);

            Console.WriteLine($"Title: {todo.Title}");
            Console.WriteLine($"Completed: {todo.Completed}");
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
        }
    }
}

public class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
}

