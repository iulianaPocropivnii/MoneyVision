using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Transaction.Responses
{
     public class TransactionsListResp : GenericResp
     {
          public List<TransactionDto> Transactions { get; set; }
     }
}
