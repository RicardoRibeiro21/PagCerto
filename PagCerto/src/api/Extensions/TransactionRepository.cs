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
        public TransactionFeedBack PostTransaction(TbTransaction transaction)
        {
            try
            {
                TransactionFeedBack feedBack = new TransactionFeedBack();

                using (var context = new PagCertoContext())
                {
                    decimal flatRate = Convert.ToDecimal(0.09);
                    transaction.DateTransaction = DateTime.Now;
                    transaction.NetValue = transaction.GrossValue * (1 - flatRate);
                    transaction.FlatRate = flatRate;

                    ValidationsTransaction validate = new ValidationsTransaction();
                    feedBack = validate.ValidationNumberCard(transaction.TypeCard);

                    if(feedBack.approval)
                    {
                        feedBack = validate.ValidationCardRefused(transaction.TypeCard);

                        if (feedBack.approval)
                        {
                            // Criar método de gerar parcelas
                            for (int i = 0; i < transaction.NumberParcel; i++)
                            {
                                TbParcel parcel = new TbParcel();
                                parcel.GrossValue = transaction.GrossValue / transaction.NumberParcel;
                                parcel.NetValue = transaction.GrossValue * (1 - transaction.FlatRate) / 2;
                                parcel.NumberParcel = i + 1;
                                parcel.AdvanceAmount = null;
                                parcel.DateExpectedInstallment = DateTime.Now.AddMonths(i + 1);
                                parcel.DateAdvanceInstallment = null;
                                transaction.AcquirerConfirmation = 1;
                                transaction.TbParcels.Add(parcel);
                                context.Add(parcel);
                            }
                        }
                    }                 
                    context.Add(transaction);
                    context.SaveChanges();
                }
                return feedBack;
            }
            catch (Exception ex) { throw ex; }
        }
        public List<TbTransaction> GetTransactions()
        {
            try
            {
                List<TbTransaction> listTransaction = new List<TbTransaction>();
                using (var context = new PagCertoContext())
                {
                    listTransaction = context.TbTransactions.Include("TbParcels").ToList();
                }
                return listTransaction;
            }
            catch (Exception ex) { throw ex; }
        }

        public TbTransaction GetTransactionById(int idTransaction)
        {
            try
            {
                TbTransaction transaction = new TbTransaction();
                using (var context = new PagCertoContext())
                {
                    var query = context.TbTransactions.Include("TbParcels").Where(i => i.IdTransaction == idTransaction);
                    transaction = query.FirstOrDefault<TbTransaction>();
                }
                return transaction;
            }
            catch (Exception ex) { throw ex; }
        }

        public TbTransaction UpdateConfirmationTransaction(int idTransaction, int idDecisao)
        {
            try
            {
                TbTransaction transaction = new TbTransaction();
                using (var context = new PagCertoContext())
                {
                    transaction = GetTransactionById(idTransaction);

                    if (transaction != null)
                    {
                        transaction.AcquirerConfirmation = idDecisao;

                        if (idDecisao == 1) transaction.DateApproval = DateTime.Now;
                        else transaction.DataDisapproval = DateTime.Now;
                        
                        context.TbTransactions.Update(transaction);
                        context.SaveChanges();
                    }
                }
                return transaction;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
