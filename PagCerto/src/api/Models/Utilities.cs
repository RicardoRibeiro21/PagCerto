using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Models
{
    public class Utilities
    {
      
    }
    public class TransactionApproval
    {
        public int idTransaction { get; set; }
        public int idDecision { get; set; }
    }

    public class AnticipationApproval
    {
        public int idAnticipation { get; set; }
        public TransactionApproval[] transactionApproval { get; set; }
    }

    public class Feedback
    {
        public bool approval { get; set; }
        public string message { get; set; }
    }
}
