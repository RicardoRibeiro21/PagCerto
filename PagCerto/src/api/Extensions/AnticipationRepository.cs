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
    }
}
