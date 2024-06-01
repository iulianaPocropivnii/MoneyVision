using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.User.Responses
{
     public class UListResp : GenericResp
     {
          public List<UserDto> Users { get; set; }
     }
}
