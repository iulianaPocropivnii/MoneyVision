using MoneyVision.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Transaction.Responses
{
     public class TransactionItemResp : GenericResp
     {
          public Transaction Transaction {  get; set; }

          public List<Category.Category> Categories { get; set; }
     }
}
