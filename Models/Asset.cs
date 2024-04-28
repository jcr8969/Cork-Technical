namespace Cork_Technical.Models
{
    public class Asset
    {
        // components of the cyber asset
        public int id { get; set; }
        public string? device_name { get; set; }
        public string? type { get; set; }

        public int? serial {  get; set; }

        public string? os { get; set; }
    }
}
