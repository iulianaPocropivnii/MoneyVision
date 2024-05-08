using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Category
{
     public class Category : BaseEntity
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "Name")]
          [StringLength(32, MinimumLength = 4)]
          public string Name { get; set; }

          [Display(Name = "Description")]
          [StringLength(64)]
          public string Description { get; set; }

          [Required]
          [Display(Name = "WorkspaceId")]
          public int WorkspaceId { get; set; }
     }
}
