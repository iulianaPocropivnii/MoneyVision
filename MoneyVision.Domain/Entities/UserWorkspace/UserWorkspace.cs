using MoneyVision.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.UserWorkspace
{
     public class UserWorkspace
     {
          [Key, Column(Order = 0)]
          [Display(Name = "WorkspaceId")]
          public int WorkspaceId { get; set; }

          [Key, Column(Order = 1)]
          [Display(Name = "UserId")]
          public int UserId { get; set; }

          [Required]
          [Display(Name = "Level")]
          public UserRole Level { get; set; }
     }
}
