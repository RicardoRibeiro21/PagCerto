using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class ResultAnticipation
    {
        public ResultAnticipation()
        {
            AnticipationTransactions = new HashSet<AnticipationTransaction>();
            Anticipations = new HashSet<Anticipation>();
        }

        public int IdResult { get; set; }
        public string DescriptionResult { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<AnticipationTransaction> AnticipationTransactions { get; set; }
        public virtual ICollection<Anticipation> Anticipations { get; set; }
    }
}
