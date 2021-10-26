using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class Anticipation
    {
        public Anticipation()
        {
            AnticipationTransactions = new HashSet<AnticipationTransaction>();
        }

        public int IdAnticipation { get; set; }
        public DateTime DateRequest { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateFinish { get; set; }
        public int? IdResultAnticipation { get; set; }
        public decimal ValueRequest { get; set; }
        public decimal ValueAnticipation { get; set; }

        public virtual ResultAnticipation IdResultAnticipationNavigation { get; set; }
        public virtual ICollection<AnticipationTransaction> AnticipationTransactions { get; set; }
    }
}
