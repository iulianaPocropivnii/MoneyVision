using MoneyVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MoneyVision.Domain.Entities.User;
using MoneyVision.Domain.Entities.Category;
using MoneyVision.Domain.Entities.Transaction;
using MoneyVision.Domain.Entities.Workspace;

namespace MoneyVision.BusinessLogic.DBModel
{
     public class DatabaseContext : System.Data.Entity.DbContext
     {
          public DatabaseContext() : base("name = MoneyVision") { }

          public virtual DbSet<User> Users { get; set; }

          public virtual DbSet<Session> Sessions { get; set; }

          public virtual DbSet<Workspace> Workspaces { get; set; }

          public virtual DbSet<Transaction> Transactions { get; set; }

          public virtual DbSet<Category> Categories { get; set; }

          public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
          {
               UpdateTimestamps();
               return base.SaveChangesAsync(cancellationToken);
          }

          public override int SaveChanges()
          {
               UpdateTimestamps();
               return base.SaveChanges();
          }

          private void UpdateTimestamps()
          {
               var entities = ChangeTracker.Entries()
                   .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

               foreach (var entity in entities)
               {
                    var now = DateTime.UtcNow;

                    if (entity.State == EntityState.Added)
                    {
                         ((BaseEntity)entity.Entity).CreatedAt = now;
                    }

                   ((BaseEntity)entity.Entity).UpdatedAt = now;
               }
          }

     }
}
