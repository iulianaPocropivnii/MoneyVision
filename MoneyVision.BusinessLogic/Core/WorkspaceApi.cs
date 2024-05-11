using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.Transaction.Responses;
using MoneyVision.Domain.Entities.Workspace;
using MoneyVision.Domain.Entities.Workspace.Requests;
using MoneyVision.Domain.Entities.Workspace.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.BusinessLogic.Core
{
     public class WorkspaceApi
     {
          internal WorkspacesListResp WorkspacesListAction(WorkspacesListData data)
          {
               using (var db = new DatabaseContext())
               {
                    var workspaces = (from w in db.Workspaces
                                      join uw in db.UserWorkspaces on w.Id equals uw.WorkspaceId
                                      join u in db.Users on uw.UserId equals u.Id
                                      where uw.UserId == data.UserId
                                      orderby w.Name
                                      select new
                                      {
                                           Id = w.Id,
                                           Name = w.Name,
                                           CreatedAt = w.CreatedAt,
                                           UpdatedAt = w.UpdatedAt
                                      }).ToList()
                                        .ToList()
                                        .Select(x => new Workspace
                                        {
                                             Id = x.Id,
                                             Name = x.Name,
                                             CreatedAt = x.CreatedAt,
                                             UpdatedAt = x.UpdatedAt,
                                        }).ToList();

                    return new WorkspacesListResp { Status = true, Workspaces = workspaces };
               }
          }
     }
}
