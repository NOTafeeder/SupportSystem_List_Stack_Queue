using SupportSystem_List_Stack_Queue.Models;

namespace SupportSystem_List_Stack_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HelpDesk helpDesk = new HelpDesk();
            helpDesk.AddCustomer(new Customer(1, "Alice"));
            helpDesk.AddCustomer(new Customer(2, "Bob"));
            helpDesk.AddCustomer(new Customer(3, "Charlie"));
            helpDesk.AddCustomer(new Customer(4, "Diana"));
            helpDesk.ShowCustomers();

            Console.WriteLine("-----------------Tickets------------------");
            helpDesk.AddTicket(1, "Cannot access account");
            helpDesk.AddTicket(2, "Password reset needed");
            helpDesk.AddTicket(3, "Error message on login");
            helpDesk.AddTicket(4, "Software installation issues");

            Console.WriteLine("-----------------Handling Tickets------------------");
            helpDesk.HandleNextTicket();
            helpDesk.HandleNextTicket();
            helpDesk.HandleNextTicket();
            helpDesk.HandleNextTicket();
            helpDesk.HandleNextTicket();

            Console.WriteLine("-----------------Reopening Last Closed Ticket------------------");
            helpDesk.ReopenLastClosedTicket();
            helpDesk.ReopenLastClosedTicket();
            helpDesk.ReopenLastClosedTicket();
            helpDesk.ReopenLastClosedTicket();
            helpDesk.ReopenLastClosedTicket();
            Console.ReadKey();
        }
    }
}
