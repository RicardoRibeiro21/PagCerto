﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Models
{
    public class TransactionUtilities
    {
      
    }
    public class TransactionApproval
    {
        public int idTransaction { get; set; }
        public int idDecision { get; set; }
    }
    public class TransactionFeedBack
    {
        public bool approval { get; set; }
        public string message { get; set; }
    }
}