using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Transaction.Requests
{
     public class TransactionsCreateData
     {
          public int WorkspaceId { get; set; }
          public int CategoryId { get; set; }
          public float Amount { get; set; }
          public DateTime CreatedAt { get; set; }
          public string Description { get; set; }
     }
}
