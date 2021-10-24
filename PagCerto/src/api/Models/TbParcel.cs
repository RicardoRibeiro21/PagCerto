using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class TbParcel
    {
        public int IdParcel { get; set; }
        public int? IdTransaction { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public int NumberParcel { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public DateTime? DateExpectedInstallment { get; set; }
        public DateTime? DateAdvanceInstallment { get; set; }

        public virtual TbTransaction IdTransactionNavigation { get; set; }
    }
}
