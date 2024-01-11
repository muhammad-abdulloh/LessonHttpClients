

namespace OOPLessonN11
{
    public class Program
    {
       

        static void Main(string[] args)
        {
            // shundek qililarki 
            // 2 ta o'zgaruvchim 

            //3 - o'zgaruvchi olaman

        }
    }
}
/** 
 *  o'qib olish uchun

        string json = File.ReadAllText("path/to/your/json/file.json");
        JObject data = JObject.Parse(json);

        string name = data["person"]["name"].Value<string>();
        int age = data["person"]["age"].Value<int>();
        string city = data["person"]["address"]["city"].Value<string>();

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"City: {city}");



// yangi q'shish

        string jsonFilePath = "path/to/your/json/file.json";
        string existingJson = File.ReadAllText(jsonFilePath);

        // O'qilgan JSON ma'lumotlarni deserializatsiya qilish
        JObject jsonData = JObject.Parse(existingJson);

        // Yangi JSON ma'lumotni tuzish
        dynamic newJsonData = new
        {
            title = "Yangi Fikr",
            content = "Bu yangi JSON faylga qo'shilgan fikr.",
            author = "Men",
            date = DateTime.Now
        };

        // Yangi JSON ma'lumotlarini mavjud JSON obyektiga qo'shish
        jsonData["newData"] = JToken.FromObject(newJsonData);

        // JSON obyektlarni JSON formatiga o'tkazib, JSON faylga yozish
        string updatedJson = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        File.WriteAllText(jsonFilePath, updatedJson);

        Console.WriteLine("Yangi ma'lumot JSON faylga qo'shildi.");


// yangi malumotlar qo'shish

        // Ichma ich bo'lgan JSON ma'lumotlarni tuzish
        dynamic jsonData = new List<dynamic>();
        for (int i = 1; i <= 50; i++)
        {
            dynamic item = new
            {
                id = i,
                name = "Element " + i,
                value = i * 10
            };
            jsonData.Add(item);
        }

        // JSON formatiga o'tkazib, JSON faylga yozish
        string json = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        File.WriteAllText("path/to/your/json/file.json", json);

        Console.WriteLine("Ichma ich bo'lgan JSON fayl yaratildi.");



    // object to json 

        dynamic data = new
        {
            person = new
            {
                name = "John",
                age = 30,
                address = new
                {
                    city = "New York",
                    country = "USA"
                }
            }
        };

        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        Console.WriteLine(json);

// json to Object 


using System;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string json = @"{
            ""person"": {
                ""name"": ""John"",
                ""age"": 30,
                ""address"": {
                    ""city"": ""New York"",
                    ""country"": ""USA""
                }
            }
        }";

        PersonModel person = JsonConvert.DeserializeObject<PersonModel>(json);

        Console.WriteLine("Name: " + person.Person.Name);
        Console.WriteLine("Age: " + person.Person.Age);
        Console.WriteLine("City: " + person.Person.Address.City);
        Console.WriteLine("Country: " + person.Person.Address.Country);
    }
}

public class PersonModel
{
    public PersonDetailsModel Person { get; set; }
}

public class PersonDetailsModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public AddressModel Address { get; set; }
}

public class AddressModel
{
    public string City { get; set; }
    public string Country { get; set; }
}

 * 
 */