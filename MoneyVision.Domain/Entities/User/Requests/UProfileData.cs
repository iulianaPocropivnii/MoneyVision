using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.User.Requests
{
     public class UProfileData
     {
          public string NewUsername { get; set; }
          public string CurrentPassword { get; set; }
          public string NewPassword { get; set; }
     }
}
