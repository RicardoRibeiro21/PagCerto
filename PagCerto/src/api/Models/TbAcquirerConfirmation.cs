using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class TbAcquirerConfirmation
    {
        public TbAcquirerConfirmation()
        {
            TbTransactions = new HashSet<TbTransaction>();
        }

        public int IdStatus { get; set; }
        public string DescriptionAcquirer { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<TbTransaction> TbTransactions { get; set; }
    }
}
