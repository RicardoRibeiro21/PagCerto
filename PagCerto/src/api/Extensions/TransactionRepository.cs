using Microsoft.EntityFrameworkCore;
using PagCerto.src.api.Migrations;
using PagCerto.src.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Extensions
{
    public class TransactionRepository
    {
        public Feedback PostTransaction(Transaction transaction)
        {
            try
            {
                Feedback feedBack = new Feedback();

                using (var context = new PagCertoContext())
                {
                    decimal flatRate = Convert.ToDecimal(0.09);
                    transaction.DateTransaction = DateTime.Now;
                    transaction.NetValue = transaction.GrossValue * (1 - flatRate);
                    transaction.FlatRate = flatRate;

                    ValidationsTransaction validate = new ValidationsTransaction();
                    feedBack = validate.ValidationNumberCard(transaction.TypeCard);

                    if (feedBack.approval)
                    {
                        feedBack = validate.ValidationCardRefused(transaction.TypeCard);

                        if (feedBack.approval)
                        {
                            // Criar método de gerar parcelas
                            for (int i = 0; i < transaction.NumberParcel; i++)
                            {
                                Parcel parcel = new Parcel();
                                parcel.GrossValue = transaction.GrossValue / transaction.NumberParcel;
                                parcel.NetValue = transaction.GrossValue * (1 - transaction.FlatRate) / 2;
                                parcel.NumberParcel = i + 1;
                                parcel.AdvanceAmount = null;
                                parcel.DateExpectedInstallment = DateTime.Now.AddMonths(i + 1);
                                parcel.DateAdvanceInstallment = null;
                                transaction.AcquirerConfirmation = 1;
                                transaction.Parcels.Add(parcel);
                                transaction.TypeCard = transaction.TypeCard.Substring(transaction.TypeCard.Length-4);
                                context.Add(parcel);
                            }
                            context.Add(transaction);
                            context.SaveChanges();

                            feedBack.message = "Transação cadastrada com sucesso.";
                        }
                    }
                }
                return feedBack;
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Transaction> GetTransactions()
        {
            try
            {
                List<Transaction> listTransaction = new List<Transaction>();
                using (var context = new PagCertoContext())
                {
                    listTransaction = context.Transactions.Include("Parcels").ToList();
                }
                return listTransaction;
            }
            catch (Exception ex) { throw ex; }
        }

        public Transaction GetTransactionById(int idTransaction)
        {
            try
            {
                Transaction transaction = new Transaction();
                using (var context = new PagCertoContext())
                {
                    var query = context.Transactions.Include("Parcels").Where(i => i.IdTransaction == idTransaction);
                    transaction = query.FirstOrDefault<Transaction>();
                }
                return transaction;
            }
            catch (Exception ex) { throw ex; }
        }

        public Transaction UpdateConfirmationTransaction(int idTransaction, int idDecisao)
        {
            try
            {
                Transaction transaction = new Transaction();
                using (var context = new PagCertoContext())
                {
                    transaction = GetTransactionById(idTransaction);

                    if (transaction != null)
                    {
                        transaction.AcquirerConfirmation = idDecisao;

                        if (idDecisao == 1) transaction.DateApproval = DateTime.Now;
                        else transaction.DataDisapproval = DateTime.Now;

                        context.Transactions.Update(transaction);
                        context.SaveChanges();
                    }
                }
                return transaction;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
