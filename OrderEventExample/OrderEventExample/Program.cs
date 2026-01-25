using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEventExample
{
    public class OrderEventArguments : EventArgs
    {
        public int OrderID
        {
            get;set;
        }
        public int TotalPrice
        {
            get;set;
        }
        public string ClientEmail
        {
            get;set;
        }
        public OrderEventArguments(int OrderID, int TotalPrice, string ClientEmail)
        {
            this.OrderID = OrderID;
            this.TotalPrice = TotalPrice;
            this.ClientEmail = ClientEmail;
        }
    }
    public class Order
    {
        public event EventHandler<OrderEventArguments> OnOrderCreated;
        public void OnOrder(int OrderID, int TotalPrice, string ClientEmail)
        {
            if (OnOrderCreated!=null)
                OnOrderCreated(this,new OrderEventArguments(OrderID,TotalPrice,ClientEmail));
        }
        //protected virtual void OnOrder(OrderEventArguments e)
        //{
        //    OnOrderCreated?.Invoke(this, e);
        //}
    }
    public class EmailService
    {

        public void Subscribe(Order order)
        {
            order.OnOrderCreated += HandleEvent;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= HandleEvent;
        }
        private void HandleEvent(object sender , OrderEventArguments e)
        {
            Console.WriteLine("----------- Email Service -----------");
            Console.WriteLine("Email service Object receive a new order event");
            Console.WriteLine($"OrderID:{e.OrderID}");
            Console.WriteLine($"TotalPrice: {e.TotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine("\nSending an email");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
    public class SMSService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderCreated += HandleEvent;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= HandleEvent;
        }
        private void HandleEvent(object sender, OrderEventArguments e)
        {
            Console.WriteLine("----------- SMS Service -----------");
            Console.WriteLine("SMS service Object receive a new order event");
            Console.WriteLine($"OrderID:{e.OrderID}");
            Console.WriteLine($"TotalPrice: {e.TotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine("\nSending an SMS");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
    public class ShipingService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderCreated += HandleEvent;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderCreated -= HandleEvent;
        }
        private void HandleEvent(object sender, OrderEventArguments e)
        {
            Console.WriteLine("----------- Shiping Service -----------");
            Console.WriteLine("Shiping service Object receive a new order event");
            Console.WriteLine($"OrderID:{e.OrderID}");
            Console.WriteLine($"TotalPrice: {e.TotalPrice}");
            Console.WriteLine($"Email: {e.ClientEmail}");
            Console.WriteLine("\nSending an Shiping");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            
            EmailService emailService = new EmailService();
            emailService.Subscribe(order);
            SMSService smsService = new SMSService();
            smsService.Subscribe(order);
            ShipingService shipingService = new ShipingService();
            shipingService.Subscribe(order);
            order.OnOrder(1, 10000, "m@gmail.com");
        }
    }
}
