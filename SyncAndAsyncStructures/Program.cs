using HttpClientSyncStructure;
using System.Net.Http.Json;

HttpClient? client = new();
HttpRequestMessage request = new(HttpMethod.Get, "https://jsonplaceholder.typicode.com/todos");
HttpResponseMessage? reponse = client.Send(request);

if(reponse.IsSuccessStatusCode)
{
    List<Todo>? todoList = reponse.Content.ReadFromJsonAsync<List<Todo>>().Result;

    if(todoList is not null)
    {
        foreach(Todo todos in todoList)
        {
            Console.WriteLine($"id: {todos.Id}, title: {todos.Title}, completed: {todos.Completed}, userId: {todos.UserId}");
        }
    }
    else
    {
        Console.WriteLine("The list is empty!");
    }
}
else
{
    Console.Write($"HTTP ERROR: {reponse.StatusCode}");
}
