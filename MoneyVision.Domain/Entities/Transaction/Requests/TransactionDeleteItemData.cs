using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Transaction.Requests
{
     public class TransactionDeleteItemData
     {
          public int Id { get; set; }
          public int WorkspaceId { get; set; }
     }
}
