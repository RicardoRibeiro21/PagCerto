using PagCerto.src.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagCerto.src.api.Extensions
{
    public class ValidationsTransaction
    {
        public TransactionFeedBack ValidationNumberCard(string numberCard)
        {
            TransactionFeedBack transactionFeedBack = new TransactionFeedBack();
            if (!String.IsNullOrEmpty(numberCard))
            {
                if (numberCard.Any(char.IsDigit))
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
        public TransactionFeedBack ValidationCardRefused(string numberCard)
        {
            TransactionFeedBack transactionFeedBack = new TransactionFeedBack();
            if (!String.IsNullOrEmpty(numberCard))
            {
                if (numberCard.PadLeft(4) == "5999")
                {
                    transactionFeedBack.approval = true;
                    transactionFeedBack.message = "Cartão aprovado.";
                    return transactionFeedBack;
                }
            }
            transactionFeedBack.approval = false;
            transactionFeedBack.message = "Cartão recusado.";

            return transactionFeedBack;
        }
    }
}
