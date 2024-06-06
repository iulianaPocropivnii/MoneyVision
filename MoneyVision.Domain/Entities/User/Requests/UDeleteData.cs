using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.User.Requests
{
     public class UDeleteData
     {
          public int WorkspaceId { get; set; }
          public int UserId { get; set; }
     }
}
