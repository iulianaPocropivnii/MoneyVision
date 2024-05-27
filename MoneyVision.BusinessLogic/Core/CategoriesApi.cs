using MoneyVision.Domain.Entities.Category.Responses;
using MoneyVision.Domain.Entities.Category.Requests;
using System;
using System.Linq;
using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.Workspace;
using System.Collections.Generic;

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
    }
}
