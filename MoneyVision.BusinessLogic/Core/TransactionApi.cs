using MoneyVision.Domain.Entities.Transaction.Responses;
using MoneyVision.Domain.Entities.Transaction.Requests;
using System;
using System.Linq;
using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.Workspace;
using System.Collections.Generic;
using MoneyVision.Domain.Entities.Transaction;

namespace MoneyVision.BusinessLogic.Core
{
     public class TransactionApi
     {
          internal TransactionsListResp TransactionsListAction(TransactionsListData data)
          {
               using (var db = new DatabaseContext())
               {
                    var transactions = (from t in db.Transactions
                                        join c in db.Categories on t.CategoryId equals c.Id
                                        where t.WorkspaceId == data.WorkspaceId
                                        orderby t.CreatedAt
                                        select new
                                        {
                                             Id = t.Id,
                                             WorkspaceId = t.WorkspaceId,
                                             Category = c.Name,
                                             CategoryId = c.Id,
                                             Description = t.Description,
                                             Amount = t.Amount,
                                             CreatedAt = t.CreatedAt,
                                             UpdatedAt = t.UpdatedAt,
                                        }).ToList()
                                        .Select(x => new TransactionDto
                                        {
                                             Id = x.Id,
                                             WorkspaceId = x.WorkspaceId,
                                             Category = x.Category,
                                             CategoryId = x.CategoryId,
                                             Description = x.Description,
                                             Amount = x.Amount,
                                             CreatedAt = x.CreatedAt,
                                             UpdatedAt = x.UpdatedAt,
                                        })
                    .ToList();

                    return new TransactionsListResp { Status = true, Transactions = transactions };
               }

          }

          internal TransactionsCreateResp TransactionsCreateAction(TransactionsCreateData data)
          {
               using (var db = new DatabaseContext())
               {
                    Transaction transaction;

                    transaction = db.Transactions.Create();

                    transaction.CreatedAt = data.CreatedAt;
                    transaction.CategoryId = data.CategoryId;
                    transaction.Amount = data.Amount;
                    transaction.WorkspaceId = data.WorkspaceId;
                    transaction.Description = data.Description;

                    var transactions = db.Transactions.Add(transaction);
                    db.SaveChanges();

                    return new TransactionsCreateResp { Status = true };
               }

          }
     }
}
