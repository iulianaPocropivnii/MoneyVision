﻿using MoneyVision.Domain.Entities.Transaction.Responses;
using MoneyVision.Domain.Entities.Transaction.Requests;
using System;
using System.Linq;
using MoneyVision.BusinessLogic.DBModel;
using MoneyVision.Domain.Entities.Workspace;
using System.Collections.Generic;
using MoneyVision.Domain.Entities.Transaction;
using MoneyVision.Domain.Entities.User;
using System.Data.Entity;

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

          internal TransactionItemResp TransactionItemAction(TransactionItemData data)
          {
               Transaction transaction;

               using (var db = new DatabaseContext())
               {
                    transaction = db.Transactions.FirstOrDefault(t => t.WorkspaceId == data.WorkspaceId && t.Id == data.Id);
               }

               if (transaction == null)
                    return new TransactionItemResp { Status = false, StatusMsg = "Transaction not found" };

               return new TransactionItemResp { Status = true, Transaction = transaction };
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

          internal TransactionsUpdateResp TransactionsUpdateAction(TransactionsUpdateData data)
          {
               using (var db = new DatabaseContext())
               {
                    Transaction transaction = db.Transactions.FirstOrDefault(t => t.WorkspaceId == data.WorkspaceId && t.Id == data.Id);

                    if (transaction == null)
                    {
                         return new TransactionsUpdateResp { StatusMsg = "Transaction Not Found", Status = false };
                    }

                    transaction.CreatedAt = data.CreatedAt;
                    transaction.CategoryId = data.CategoryId;
                    transaction.Amount = data.Amount;
                    transaction.Description = data.Description;

                    db.Entry(transaction).State = EntityState.Modified;

                    db.SaveChanges();

                    return new TransactionsUpdateResp { Status = true };
               }

          }

          internal TransactionDeleteItemResp TransactionDeleteItemAction(TransactionDeleteItemData data)
          {
               using (var db = new DatabaseContext())
               {
                    Transaction transaction = db.Transactions.FirstOrDefault(t => t.WorkspaceId == data.WorkspaceId && t.Id == data.Id);

                    if (transaction == null)
                    {
                         return new TransactionDeleteItemResp { StatusMsg = "Transaction Not Found", Status = false };
                    }

                    db.Transactions.Remove(transaction);

                    return new TransactionDeleteItemResp { Status = true };
               }
          }
     }
}
