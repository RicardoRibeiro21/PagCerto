using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class AnticipationTransaction
    {
        public int IdAnticipationTransaction { get; set; }
        public int? IdAnticipation { get; set; }
        public int? IdResultAnticipation { get; set; }
        public int? IdTransaction { get; set; }

        public virtual Anticipation IdAnticipationNavigation { get; set; }
        public virtual ResultAnticipation IdResultAnticipationNavigation { get; set; }
        public virtual Transaction IdTransactionNavigation { get; set; }
    }
}
