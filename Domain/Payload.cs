using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Payload
    {
        [Key]
        public int loadId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}