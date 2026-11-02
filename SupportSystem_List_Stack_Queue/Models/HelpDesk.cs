using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SupportSystem_List_Stack_Queue.Models
{
    internal class HelpDesk
    {
        // All Customers List<T>
        private List<Customer> customers = new List<Customer>();

        // Look up Customer by ID
        private Dictionary<int, Customer> customerLookup = new Dictionary<int, Customer>();

        // Incoming Tickets FIFO Queue<T>
        private Queue<Ticket> ticketQueue = new Queue<Ticket>();

        // Closed Tickets LIFO Stack<T>
        private Stack<Ticket> closedTickets = new Stack<Ticket>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
            customerLookup[customer.ID] = customer;
            Console.WriteLine($"Customer added: {customer.Name}, ID: {customer.ID}");
        }
        public void ShowCustomers()
        {
            Console.WriteLine("----------All Customers-----------");
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}");
            }
        }
        public void AddTicket(int customerID, string issue)
        {
            if(!customerLookup.ContainsKey(customerID))
            {
                Console.WriteLine($"Customer not found with this ID: [{customerID}]");
                return;
            }
            ticketQueue.Enqueue(new Ticket(customerID, issue));
            Console.WriteLine($"Ticket added for {customerLookup[customerID].Name}: Issue: {issue}");
        }
        public void HandleNextTicket()
        {
            // Check if there are tickets to handle
            if (ticketQueue.Count == 0)
            {
                Console.WriteLine("No tickets to handle, please try again later.");
                return;
            }
            // Remove ticket from collection and process it
            Ticket ticket = ticketQueue.Dequeue();
            // show message to the user handling the ticket for the customer
            Customer customer = customerLookup[ticket.CustomerID];
            Console.WriteLine($"Handling ticket for {customer.Name}: Issue: {ticket.Issue}");
            // Add the ticket to the closed tickets stack
            closedTickets.Push(ticket); 
        }
        public void ReopenLastClosedTicket()
        {
            // Check if there are closed tickets to reopen
            if (closedTickets.Count == 0)
            {
                Console.WriteLine("No closed tickets to reopen.");
                return;
            }
            // Remove ticket from closed tickets stack and add it back to the queue
            Ticket ticket = closedTickets.Pop();
            ticketQueue.Enqueue(ticket);
            Console.WriteLine($"Reopened ticket for Issue: {ticket.Issue}");
        }
    }
}
