using System.Text.Json.Serialization;

namespace RickAndMortyAPI.Models
{
    public class Result
    {
        [JsonIgnore]
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public Origin origin { get; set; }
    }

}
