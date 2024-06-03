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
        }
 }


