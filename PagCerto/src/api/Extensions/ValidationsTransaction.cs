using PagCerto.src.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Extensions
{
    public class ValidationsTransaction
    {
        public Feedback ValidationNumberCard(string numberCard)
        {
            Feedback transactionFeedBack = new Feedback();
            if (!String.IsNullOrEmpty(numberCard))
            {
                if (numberCard.All(char.IsDigit) && numberCard.Length == 16)
                {
                    transactionFeedBack.approval = true;
                    transactionFeedBack.message = "Cartão válido.";
                    return transactionFeedBack;
                }
            }
            transactionFeedBack.approval = false;
            transactionFeedBack.message = "Cartão inválido.";

            return transactionFeedBack;
        }
        public Feedback ValidationCardRefused(string numberCard)
        {
            Feedback transactionFeedBack = new Feedback();
            if (!String.IsNullOrEmpty(numberCard))
            {
                if (numberCard.PadLeft(4) == "5999")
                {
                    transactionFeedBack.approval = false;
                    transactionFeedBack.message = "Cartão recusado.";                    
                    return transactionFeedBack;
                }
            }
            transactionFeedBack.approval = true;
            transactionFeedBack.message = "Cartão aprovado.";

            return transactionFeedBack;
        }
    }
}
