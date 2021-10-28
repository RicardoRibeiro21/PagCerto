using Microsoft.EntityFrameworkCore;
using PagCerto.src.api.Migrations;
using PagCerto.src.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Extensions
{
    public class AnticipationRepository
    {
        public List<Anticipation> GetAnticipations()
        {
            try
            {
                List<Anticipation> listAnticipation = new List<Anticipation>();
                using (var context = new PagCertoContext())
                {
                    listAnticipation = context.Anticipations.Include("AnticipationTransactions").ToList();
                }
                return listAnticipation;
            }
            catch (Exception ex) { throw ex; }
        }

        public Anticipation GetAnticipationById(int idAnticipation)
        {
            try
            {
                Anticipation anticipation = new Anticipation();
                using (var context = new PagCertoContext())
                {
                    var query = context.Anticipations.Include("AnticipationTransactions").Where(i => i.IdAnticipation == idAnticipation);
                    anticipation = query.FirstOrDefault<Anticipation>();
                }
                return anticipation;
            }
            catch (Exception ex) { throw ex; }
        }

        public Feedback PostAnticipation(Anticipation anticipation)
        {
            try
            {
                Feedback feedBack = new Feedback();

                using (var context = new PagCertoContext())
                {
                    context.Add(anticipation);
                    context.SaveChanges();
                }
                return feedBack;
            }
            catch (Exception ex) { throw ex; }
        }

        public Feedback PutAnticipation(AnticipationApproval anticipationApproval)
        {
            try
            {
                Feedback feedback = new Feedback();
                Anticipation anticipation = new Anticipation();
                TransactionRepository transactionRepository = new TransactionRepository();
                Transaction transaction = new Transaction();

                using (var context = new PagCertoContext())
                {
                    anticipation = GetAnticipationById(anticipationApproval.idAnticipation);

                    if (anticipation != null)
                    {
                        foreach (var item in anticipationApproval.transactionApproval)
                        {
                            // Resgata a transação
                            transaction = transactionRepository.GetTransactionById(Convert.ToInt32(item.idTransaction));

                            if (item.idDecision == 1)
                            {
                                // Seta a data de aprovação da antecipação da transação 
                                transaction.DateApproval = DateTime.Now;

                                // Atualiza o valor (debitado da taxa) e a data antecipada
                                foreach (var parcel in transaction.Parcels)
                                {
                                    parcel.AdvanceAmount = parcel.NetValue * Convert.ToDecimal(1 - 0.038);
                                    parcel.DateAdvanceInstallment = DateTime.Now;
                                }
                            }
                            else if (item.idDecision == 3) transaction.DataDisapproval = DateTime.Now;
                        }

                        // Seleciona se existe alguma transação recusada
                        var query = context.AnticipationTransactions.Where(i => i.IdAnticipation == anticipationApproval.idAnticipation && i.IdResultAnticipation == 3);
                        AnticipationTransaction anticipationTransaction = query.FirstOrDefault<AnticipationTransaction>();

                        // Verificar qual o resultado da antecipação                        
                        if (query.Count() == anticipation.AnticipationTransactions.Count()) anticipation.IdResultAnticipation = 3;
                        else if (query.Count() > 0) anticipation.IdResultAnticipation = 2;
                        else anticipation.IdResultAnticipation = 1;

                        context.Anticipations.Update(anticipation);
                        int saves = context.SaveChanges();

                        if (saves > 0)
                        {
                            feedback.approval = true;
                            feedback.message = "Antecipação atualizada com sucesso!";
                        }
                        return feedback;
                    }
                }
                feedback.approval = false;
                feedback.message = "Falha ao atualizar antecipação!";

                return feedback;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
