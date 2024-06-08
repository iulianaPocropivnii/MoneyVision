using MoneyVision.Domain.Entities.Category.Responses;
using MoneyVision.Domain.Entities.Category.Requests;
using System;
using System.Linq;
using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.Workspace;
using System.Collections.Generic;
using MoneyVision.Domain.Entities.User.Requests;
using MoneyVision.Domain.Entities.UserWorkspace;
using MoneyVision.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using MoneyVision.Domain.Entities.Category;
using MoneyVision.Domain.Entities.User.Responses;
using MoneyVision.Domain.Entities.Transaction.Responses;
using System.Data.Entity;
using MoneyVision.Domain.Entities.Transaction.Requests;
using MoneyVision.Domain.Entities.Transaction;

namespace MoneyVision.BusinessLogic.Core
{

    public class CategoriesApi
    {
        internal CategoriesListResp CategoriesListAction(CategoriesListData data)
        {
            using (var db = new DatabaseContext())
            {
                var categories = db.Categories.Where(c => c.WorkspaceId == data.WorkspaceId).ToList();

                return new CategoriesListResp { Status = true, Categories = categories };
            }

        }
     
        internal GenericResp AddCategoryAction(CategoryAddData data)
        {
            Category category;
            using (var db = new DatabaseContext())
            {
               category = db.Categories.Create();
               category.Name = data.Name;
                category.WorkspaceId = data.WorkspaceId;

                db.Categories.Add(category);
                db.SaveChanges();
            }
            if (category == null)
                return new GenericResp { Status = false };

            return new GenericResp { Status = true };
        }

        internal CategoryItemResp CategoryItemAction(CategoryItemData data)
        {
            Category category;

            using (var db = new DatabaseContext())
            {
                category = db.Categories.FirstOrDefault(t => t.WorkspaceId == data.WorkspaceId && t.Id == data.Id);
            }

            if (category == null)
                return new CategoryItemResp { Status = false, StatusMsg = "Category not found" };

            return new CategoryItemResp { Status = true, Category = category };
        }

        internal CategoryUpdateResp CategoryUpdateAction(CategoryUpdateData data)
        {
            using (var db = new DatabaseContext()) 
            {
                Category category =db.Categories.FirstOrDefault(t => t.WorkspaceId == data.WorkspaceId && t.Id == data.Id);
                if(category == null)
                {
                    return new CategoryUpdateResp { StatusMsg = "Category Not Found", Status = false };
                }
                category.Name = data.Name;
                category.WorkspaceId = data.WorkspaceId;

                db.Entry(category).State = EntityState.Modified;

                db.SaveChanges();

                return new CategoryUpdateResp { Status = true };

            }
        }

          internal CategoryDeleteResp CategoryDeleteAction(CategoryDeleteData data)
          {
               using (var db = new DatabaseContext())
               {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                         try
                         {
                              // Execute the delete commands using raw SQL
                              int transactionsDeleted = db.Database.ExecuteSqlCommand(
                                  "DELETE FROM Transactions WHERE CategoryId = {1} AND WorkspaceId = {0}",
                                  data.WorkspaceId, data.Id);

                              int categoryDeleted = db.Database.ExecuteSqlCommand(
                                  "DELETE FROM Categories WHERE WorkspaceId = {0} AND Id = {1}",
                                  data.WorkspaceId, data.Id);

                              // Check if the category was successfully deleted
                              if (categoryDeleted == 0)
                              {
                                   transaction.Rollback();
                                   return new CategoryDeleteResp { StatusMsg = "Category Not Found", Status = false };
                              }

                              // Commit the transaction
                              transaction.Commit();

                              return new CategoryDeleteResp { Status = true };
                         }
                         catch (Exception)
                         {
                              // Rollback the transaction in case of an error
                              transaction.Rollback();
                              throw;
                         }
                    }
               }
          }
     }
 }


