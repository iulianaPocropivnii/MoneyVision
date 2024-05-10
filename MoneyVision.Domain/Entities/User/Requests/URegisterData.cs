using System;

namespace MoneyVision.Domain.Entities.User.Requests
{
     public class URegisterData
     {
          public string Username { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public string RegisterIp { get; set; }
          public DateTime RegisterDateTime { get; set; }
     }
}
