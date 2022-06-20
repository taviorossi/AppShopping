﻿using AppShopping.Libraries.Enums;
using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppShopping.Services
{
    public class TicketService
    {
        private List<Ticket> fakeTickets = new List<Ticket>()
        {
            new Ticket() { Number = "109703757667", StartDate = new DateTime(2020, 10, 20, 16, 02, 32), EndDate = new DateTime(2020, 10, 20, 18, 02, 32), Price = 6.20m, Status = Libraries.Enums.TicketStatus.paid },
            new Ticket() { Number = "109703337667", StartDate = new DateTime(2020, 10, 22, 10, 02, 32), EndDate = new DateTime(2020, 10, 22, 12, 02, 32), Price = 12.20m, Status = Libraries.Enums.TicketStatus.paid },
            new Ticket() { Number = "209883557324", StartDate = new DateTime(2020, 10, 20, 18, 56, 42), EndDate = new DateTime(2020, 10, 22, 12, 02, 32), Price = 12.20m, Status = Libraries.Enums.TicketStatus.pending },
            new Ticket() { Number = "359645757789", StartDate = new DateTime(2020, 10, 20, 20, 32, 01), EndDate = new DateTime(2020, 10, 22, 12, 02, 32), Price = 12.20m, Status = Libraries.Enums.TicketStatus.pending }
        };
        public List<Ticket> GetTicketsPaid()
        {
            return fakeTickets.Where(a=>a.Status == TicketStatus.paid).ToList();
        }
        public Ticket GetTicketInfo(string number)
        {
            var endDate = new DateTime(2020, 10, 20, 22, 00, 00);

            var ticket = fakeTickets.FirstOrDefault(a => a.Number == number);

            if (ticket == null)
                throw new Exception("Ticket não encontrado!");

            if (ticket.Status == TicketStatus.paid)
                throw new Exception("Ticket já pago!");

            ticket.EndDate = endDate;
            ticket.Price = 6.00m;

            return ticket;
        }

        internal void getTicketInfo(string ticketNumber)
        {
            throw new NotImplementedException();
        }
    }
}
