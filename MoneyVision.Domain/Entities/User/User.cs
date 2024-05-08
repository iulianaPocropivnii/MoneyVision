using MoneyVision.Domain.Entities.User.Responses;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MoneyVision.Domain.Enums;

namespace MoneyVision.Domain.Entities.User

{
     public class User : BaseEntity
     {

          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "Username")]
          [StringLength(30, MinimumLength = 3, ErrorMessage = "Username cannot be loger then 30 characters")]
          public string Username { get; set; }

          [Required]
          [Display(Name = "Password")]
          [StringLength(40, MinimumLength = 8)]
          public string Password { get; set; }

          [Required]
          [Display(Name = "WorkspaceId")]
          public int WorkspaceId { get; set; }

          [Required]
          [Display(Name = "Email")]
          [StringLength(64)]
          public string Email { get; set; }

          [DataType(DataType.Date)]
          public DateTime? LastLogin { get; set; }

          [StringLength(30)]
          public string LastIp { get; set; }

          public UserRole Level { get; set; }
     }
}