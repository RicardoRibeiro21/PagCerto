using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class AcquirerConfirmation
    {
        public AcquirerConfirmation()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int IdStatus { get; set; }
        public string DescriptionAcquirer { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
