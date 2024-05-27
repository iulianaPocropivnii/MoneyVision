using MoneyVision.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.User.Requests
{
     public class UAddData
     {
          public string Email { get; set; }
          public int WorkspaceId { get; set; }
          public UserRole Role { get; set; }
     }
}
