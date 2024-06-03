using MoneyVision.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Category.Requests
{
    public class CategoryAddData
    {
        public string Name { get; set; }
        public int WorkspaceId { get; set; }
    }
}
