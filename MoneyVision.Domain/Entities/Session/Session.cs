using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.User
{
        public class Session
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [StringLength(30)]
            public string Email { get; set; }

            [Required]
            public string CookieString { get; set; }

            [Required]
            public DateTime ExpireTime { get; set; }
        }
    }
