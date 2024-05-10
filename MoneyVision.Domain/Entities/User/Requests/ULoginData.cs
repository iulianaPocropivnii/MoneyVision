using System;

namespace MoneyVision.Domain.Entities.User.Requests
{
     public class ULoginData
     {
          public string Email { get; set; }
          public string Password { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDateTime { get; set; }
     }
}
