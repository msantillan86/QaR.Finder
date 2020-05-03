using System.ComponentModel.DataAnnotations;

namespace QaR.Finder.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
