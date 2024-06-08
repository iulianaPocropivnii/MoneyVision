using MoneyVision.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.User.Requests
{
     public class UChangeRoleData
     {
          public int UserId { get; set; }
          public int WorkspaceId { get; set; }
          public UserRole Level { get; set; }
     }
}
