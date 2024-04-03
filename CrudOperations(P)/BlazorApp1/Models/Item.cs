using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Item
    {
        [Key]
        public string? lccn { get; set; }
        public string? url { get; set; }
        public string? state { get; set; }
        public string? title { get; set; }
    }
}