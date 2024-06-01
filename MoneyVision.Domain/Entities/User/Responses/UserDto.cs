using MoneyVision.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.User.Responses
{
     public class UserDto
     {
          public int Id { get; set; }
          public int WorkspaceId { get; set; }
          public string Email { get; set; }
          public UserRole Level { get; set; }
     }
}
