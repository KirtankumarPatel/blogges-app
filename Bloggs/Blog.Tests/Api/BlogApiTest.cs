using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

public class ApiTest
{
    public void TestApiIntegration()
    {
        string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";

        // Create RestClient
        var client = new RestClient(apiUrl);

        // Create a request
        var request = new RestRequest(Method.GET);

        // Execute the request and get the response
        var response = client.Execute(request);

        // Assert that the request was successful
        Assert.IsTrue(response.IsSuccessful, $"Error: {response.StatusCode} - {response.StatusDescription}");

        // Parse the JSON response into a custom object
        var todo = Newtonsoft.Json.JsonConvert.DeserializeObject<Todo>(response.Content);

        // Assert that the parsed object is not null
        Assert.IsNotNull(todo, "Parsed object is null");

        // Assert specific properties of the parsed object
        Assert.AreEqual(1, todo.UserId);
        Assert.AreEqual(1, todo.Id);
        Assert.AreEqual("delectus aut autem", todo.Title);
        Assert.IsFalse(todo.Completed, "Todo should not be completed");
    }

    public void TestTodoClassProperties()
    {
        // Arrange
        var todo = new Todo
        {
            UserId = 1,
            Id = 1,
            Title = "delectus aut autem",
            Completed = false
        };

        Assert.AreEqual(1, todo.UserId);
        Assert.AreEqual(1, todo.Id);
        Assert.AreEqual("delectus aut autem", todo.Title);
        Assert.IsFalse(todo.Completed, "Todo should not be completed");
    }
}
