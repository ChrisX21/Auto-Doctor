using System.ComponentModel.DataAnnotations;

namespace AutoDoctor.Data.Models
{
    public class Offer
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;        
        public decimal Price { get; set; } = 0;
        public string ImageUrl { get; set; } = null!;
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
