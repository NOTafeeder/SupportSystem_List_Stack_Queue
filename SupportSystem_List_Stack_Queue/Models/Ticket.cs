using System;
using System.Collections.Generic;
using System.Text;

namespace SupportSystem_List_Stack_Queue.Models
{
    internal class Ticket
    {
        public int CustomerID { get; set; }
        public string Issue { get; set; }

        public Ticket(int customerId, string issue)
        {
            CustomerID = customerId;
            Issue = issue;
        }
    }
}
