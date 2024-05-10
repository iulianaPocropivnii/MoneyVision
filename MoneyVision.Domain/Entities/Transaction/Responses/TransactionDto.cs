using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Transaction.Responses
{
     [NotMapped]
     public class TransactionDto : Transaction
     {
          public string Category { get; set; }
     }
}
