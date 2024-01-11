using LEssonClients.Database;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

namespace LEssonClients
{
    public class Program
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
        };

        static async Task Main(string[] args)
        {
            // qiymat qaytarmaydigan funksiyamizi Wait yoki await

            // qiymat qaytaradigan funksiyada .Result
            // await qiladigan bo'sak Main funksiyamiziyam async Task qilishimiz kerak bo'ladi

            HttpMethods.GetAsync(sharedClient).Wait();
            string result2 = await HttpMethods.DeleteAsync(sharedClient);
            
            Console.WriteLine(result2);


            //HttpMethods.GetAsync(sharedClient).Wait();

        }


        #region yopilsin
        static async Task GetExchange()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //client.BaseAddress = ""
                    string address = "https://nbu.uz/uz/exchange-rates/json";
                    string url = "https://jsonplaceholder.typicode.com/posts";

                    HttpResponseMessage response = await client.GetAsync(address);
                    response.EnsureSuccessStatusCode(); // Ensure that the request was successful

                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request failed: {e.Message}");
                }
            }
        }

        
       


        static async Task TestRequest(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync("todos/5");

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
        }


        static async Task PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    userId = 77,
                    id = 1,
                    title = "write code sample",
                    completed = false
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PostAsync(
                "todos",
                jsonContent);

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

            // Expected output:
            //   POST https://jsonplaceholder.typicode.com/todos HTTP/1.1
            //   {
            //     "userId": 77,
            //     "id": 201,
            //     "title": "write code sample",
            //     "completed": false
            //   }
        }



        static async Task PostAsJsonAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                "todos",
                new Todo(UserId: 9, Id: 99, Title: "Show extensions", Completed: false));

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var todo = await response.Content.ReadFromJsonAsync<Todo>();
            Console.WriteLine($"{todo}\n");

            // Expected output:
            //   POST https://jsonplaceholder.typicode.com/todos HTTP/1.1
            //   Todo { UserId = 9, Id = 201, Title = Show extensions, Completed = False }
        }


        static async Task GetFromJsonAsync(HttpClient httpClient)
        {
            var todos = await httpClient.GetFromJsonAsync<List<Todo>>(
                "todos?userId=1&completed=false");

            Console.WriteLine("GET https://jsonplaceholder.typicode.com/todos?userId=1&completed=false HTTP/1.1");
            todos?.ForEach(Console.WriteLine);
            Console.WriteLine();

            // Expected output:
            //   GET https://jsonplaceholder.typicode.com/todos?userId=1&completed=false HTTP/1.1
            //   Todo { UserId = 1, Id = 1, Title = delectus aut autem, Completed = False }
            //   Todo { UserId = 1, Id = 2, Title = quis ut nam facilis et officia qui, Completed = False }
            //   Todo { UserId = 1, Id = 3, Title = fugiat veniam minus, Completed = False }
            //   Todo { UserId = 1, Id = 5, Title = laboriosam mollitia et enim quasi adipisci quia provident illum, Completed = False }
            //   Todo { UserId = 1, Id = 6, Title = qui ullam ratione quibusdam voluptatem quia omnis, Completed = False }
            //   Todo { UserId = 1, Id = 7, Title = illo expedita consequatur quia in, Completed = False }
            //   Todo { UserId = 1, Id = 9, Title = molestiae perspiciatis ipsa, Completed = False }
            //   Todo { UserId = 1, Id = 13, Title = et doloremque nulla, Completed = False }
            //   Todo { UserId = 1, Id = 18, Title = dolorum est consequatur ea mollitia in culpa, Completed = False }
        }



        static async Task PostAsync2(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    userId = 77,
                    id = 1,
                    title = "write code sample",
                    completed = false
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PostAsync(
                "todos",
                jsonContent);

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

            // Expected output:
            //   POST https://jsonplaceholder.typicode.com/todos HTTP/1.1
            //   {
            //     "userId": 77,
            //     "id": 201,
            //     "title": "write code sample",
            //     "completed": false
            //   }
        }



        static async Task PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    userId = 1,
                    id = 1,
                    title = "foo bar",
                    completed = false
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PutAsync(
                "todos/1",
                jsonContent);

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

            // Expected output:
            //   PUT https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
            //   {
            //     "userId": 1,
            //     "id": 1,
            //     "title": "foo bar",
            //     "completed": false
            //   }
        }


        static async Task PutAsJsonAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.PutAsJsonAsync(
                "todos/5",
                new Todo(Title: "partially update todo", Completed: true));

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var todo = await response.Content.ReadFromJsonAsync<Todo>();
            Console.WriteLine($"{todo}\n");

            // Expected output:
            //   PUT https://jsonplaceholder.typicode.com/todos/5 HTTP/1.1
            //   Todo { UserId = , Id = 5, Title = partially update todo, Completed = True }
        }


        static async Task PatchAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    completed = true
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PatchAsync(
                "todos/5",
                jsonContent);

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

            // Expected output
            //   PATCH https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
            //   {
            //     "userId": 1,
            //     "id": 1,
            //     "title": "delectus aut autem",
            //     "completed": true
            //   }
        }


        static async Task DeleteAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.DeleteAsync("todos/5");

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

            // Expected output
            //   DELETE https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
            //   {}
        }

        #endregion
    }
}
