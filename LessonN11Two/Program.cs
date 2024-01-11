
using DavayLesson22.JsonModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.ObjectiveC;

namespace DavayLesson22
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string data = @"
                            {
                            ""userId"": 1,
                            ""id"": 1,
                            ""title"": ""Titlemi bu"",
                            ""body"": ""Bu yerda body bor""
                            }
             ";

            JObject obj = JObject.Parse(data);

            // filtrlash // o'qib olish
           // Console.WriteLine(obj["body"]);

            //Console.WriteLine(obj);

            // update
            obj["title"] = "Update Title";

            Console.WriteLine(obj);

            // delete

            obj.Remove("userId");

            Console.WriteLine(obj);

            // create
            obj["newProperty"] = "yangili bomi";
            obj.Add("SecondProp", "qiymati bu joyda");
            Console.WriteLine(obj);
        }
    }
}
