using QaR.Finder.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace QaR.Finder.Domain.Entities
{
    public class Item : CamposAuditoria
    {
        public int ItemId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
