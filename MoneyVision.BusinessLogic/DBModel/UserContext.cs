using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyVision.Domain.Entities.User;

namespace MoneyVision.BusinessLogic.DBModel
{
     class UserContext : DbContext
     {
          public UserContext() : 
               base("name = MoneyVision")
          {
          }
          public virtual DbSet <UDbTable> Users { get; set; }
     }
}
