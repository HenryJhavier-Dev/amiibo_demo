using System;
namespace AmiiboPedia.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Release
    {
        public string au { get; set; }
        public string eu { get; set; }
        public string jp { get; set; }
        public string na { get; set; }
    }
}
