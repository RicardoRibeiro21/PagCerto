using System;
using System.Collections.Generic;

#nullable disable

namespace PagCerto.src.api.Models
{
    public partial class WorkflowAnticipation
    {
        public WorkflowAnticipation()
        {
            Anticipations = new HashSet<Anticipation>();
        }

        public int IdWorkflow { get; set; }
        public string DescriptionWorkflow { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Anticipation> Anticipations { get; set; }
    }
}
