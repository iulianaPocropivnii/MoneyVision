﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyVision.Domain.Entities.Transaction
{
     public class Transaction : BaseEntity
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "WorkspaceId")]
          public int WorkspaceId { get; set; }

          [Required]
          [Display(Name = "CategoryId")]
          public int CategoryId { get; set; }


          [Display(Name = "Description")]
          public string Description { get; set; }

          [Required]
          [Display(Name = "Amount")]
          public float Amount { get; set; }
     }
}
