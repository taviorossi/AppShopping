using AppShopping.Helpers.MVVM;
using AppShopping.Libraries.Validators;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _messages;

        public string Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);
                Ticket = _ticketService.GetTicketInfo(value);
            }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set { SetProperty(ref _ticket, value); }
        }

        private CreditCard _creditCard;

        public CreditCard CreditCard
        {
            get { return _creditCard; }
            set
            {
                SetProperty(ref _creditCard, value);
            }
        }

        public ICommand PaymentCommand { get; set; }

        private TicketService _ticketService;
        private PaymentService _paymentService;

        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();
            _paymentService = new PaymentService();

            CreditCard = new CreditCard();

            PaymentCommand = new Command(Payment);
        }

        private void Payment()
        {
            //TODO - Validar
            try
            {
                Messages = string.Empty;
                string messages = Valid(CreditCard);

                if (string.IsNullOrEmpty(messages))
                {
                    int paymentId = _paymentService.SendPayment(CreditCard);

                    //TODO - Redirecionar para a tela de sucesso
                }
                else
                {
                    Messages = messages;
                }
            }
            catch (Exception ex)
            {
                //TODO - Colocar mensagem de erro (Redirecionar)
                //TODO - Redirecionar para a tela de erro
            }
        }

        private string Valid(CreditCard creditCard)
        {
            StringBuilder messages = new StringBuilder();

            if (string.IsNullOrEmpty(creditCard.Name))
            {
                messages.Append("O nome não foi preenchido!" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(CreditCard.Number))
            {
                messages.Append("O número do cartão não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Number.Length < 19)
            {
                messages.Append("O número do cartão está incompleto!" + Environment.NewLine);
            }

            try
            {
                var expiredString = creditCard.Expired.Split('/');
                var month = int.Parse(expiredString[0]);
                var year = int.Parse(expiredString[1]);
                new DateTime(month, year, 01);
            }
            catch (Exception ex)
            {
                messages.Append("A validade do cartão não é valida!" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(creditCard.SecurityCode))
            {
                messages.Append("O código de segurança não preenchido!" + Environment.NewLine);
            }
            else if (creditCard.SecurityCode.Length < 3)
            {
                messages.Append("O número do cartão está incompleto!" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(creditCard.Document))
            {
                messages.Append("O CPF não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Document.Length < 14)
            {
                messages.Append("O CPF está incompleto!" + Environment.NewLine);
            }
            else if (CPFValidator.IsCpf(creditCard.Document))
            {
                messages.Append("O CPF é inválido!" + Environment.NewLine);
            }

            return messages.ToString();
        }
    }
}
