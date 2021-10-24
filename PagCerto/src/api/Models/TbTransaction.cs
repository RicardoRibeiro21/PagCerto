using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class TbTransaction
    {
        public TbTransaction()
        {
            TbParcels = new HashSet<TbParcel>();
        }

        public int IdTransaction { get; set; }
        public DateTime DateTransaction { get; set; }
        public DateTime? DateApproval { get; set; }
        public DateTime? DataDisapproval { get; set; }
        public string Anticipation { get; set; }
        public int? AcquirerConfirmation { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal FlatRate { get; set; }
        public int NumberParcel { get; set; }
        public string TypeCard { get; set; }

        public virtual TbAcquirerConfirmation AcquirerConfirmationNavigation { get; set; }
        public virtual ICollection<TbParcel> TbParcels { get; set; }
    }
}
