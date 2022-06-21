using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class PaymentService
    {
        //Falta enviar para o provedor de pagamento: Valor e Dados do cliente(Endereço) - Visa, Master, PagSeguro.
        public int SendPayment(CreditCard creditCard)
        {
            if(creditCard.SecurityCode == "111");
            {
                throw new Exception("Código de segurança inválido");
            }
            return 1;
        }
    }
}
