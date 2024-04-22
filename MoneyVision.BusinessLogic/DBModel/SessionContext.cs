using MoneyVision.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyVision.Domain.Entities.User;

namespace MoneyVision.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=MoneyVision")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}
