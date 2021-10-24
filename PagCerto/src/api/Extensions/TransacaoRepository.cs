//using PagCerto.src.api.Migrations;
//using PagCerto.src.api.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PagCerto.src.api.Extensions
//{
//    public class TransacaoRepository
//    {
//        public void PostTransacao(TbTransacao transacao)
//        {
//            try
//            {
//                using(var context = new PagCertoContext())
//                {
//                    transacao.DataTransacao = DateTime.Now;                    
//                    context.Add(transacao);
//                }
//            }
//            catch (Exception ex) { throw ex; }
//        }
//        public List<TbTransacao> GetTransacoes()
//        {
//            try
//            {
//                List<TbTransacao> listTransacti
//                using (var context = new PagCertoContext())
//                {                    
                    
//                }
//            }
//            catch (Exception ex) { throw ex; }
//        }
//    }
//}
