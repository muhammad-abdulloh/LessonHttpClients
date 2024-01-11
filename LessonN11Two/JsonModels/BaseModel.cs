using Newtonsoft.Json;


namespace DavayLesson22.JsonModels
{
    public class BaseModel
    {
        [JsonProperty("meningIdiim")]
        public int Id { get; set; }

        //[JsonProperty("name")]
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public Company Company { get; set; }
    }
}
