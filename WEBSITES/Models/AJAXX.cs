using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WEBSITES.Models
{
    public class AJAXX
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}
