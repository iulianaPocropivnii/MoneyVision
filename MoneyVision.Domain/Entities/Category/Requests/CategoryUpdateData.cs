using MoneyVision.Domain.Entities.Transaction.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Category.Requests
{
    public class CategoryUpdateData : CategoryAddData
    {
        public int Id { get; set; }
    }
}
