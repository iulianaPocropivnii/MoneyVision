using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Transaction.Requests
{
     public class TransactionsUpdateData : TransactionsCreateData
     {
          public int Id { get; set; }
     }
}
