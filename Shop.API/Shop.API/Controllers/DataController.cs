using Bogus;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess;
using Shop.Domain;
using System.Security.Cryptography.Xml;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        //GET: api/<DataController>
        [HttpGet]
        public IActionResult Get()
        {
            ShopContext context = new ShopContext();

            //InvoiceStatus invoiceStatus1 = new InvoiceStatus
            //{
            //    Status = "Issued"
            //};
            //InvoiceStatus invoiceStatus2 = new InvoiceStatus
            //{
            //    Status = "Paid"
            //};
            //context.InvoiceStatuses.Add(invoiceStatus1);
            //context.InvoiceStatuses.Add(invoiceStatus2);


            //OrderItemStatus orderitemstatus1 = new OrderItemStatus
            //{
            //    Status = "Delivered"
            //};
            //OrderItemStatus orderitemstatus2 = new OrderItemStatus
            //{
            //    Status = "Out Of Stock"
            //};
            //context.OrderItemStatuses.Add(orderitemstatus1);
            //context.OrderItemStatuses.Add(orderitemstatus2);


            //OrderStatus status1 = new OrderStatus
            //{
            //    Status = "Completed"
            //};
            //OrderStatus status2 = new OrderStatus
            //{
            //    Status = "Cancelled"
            //};
            //context.OrderStatuses.Add(status1);
            //context.OrderStatuses.Add(status2);


            //PaymentMethod method1 = new PaymentMethod
            //{
            //    Method = "Credit Card"
            //};
            //PaymentMethod method2 = new PaymentMethod
            //{
            //    Method = "Debit Card"
            //};
            //PaymentMethod method3 = new PaymentMethod
            //{
            //    Method = "Upon Delivery"
            //};
            //context.PaymentMethods.Add(method1);
            //context.PaymentMethods.Add(method2);
            //context.PaymentMethods.Add(method3);


            //Category cat1 = new Category
            //{
            //    Name = "Fruits"
            //};
            //Category cat2 = new Category
            //{
            //    Name = "Vegetables"
            //};
            //Category cat3 = new Category
            //{
            //    Name = "Lemons",
            //    Parent = cat1
            //};
            //Category cat4 = new Category
            //{
            //    Name = "Apples",
            //    Parent = cat1
            //};
            //Category cat5 = new Category
            //{
            //    Name = "Melons",
            //    Parent = cat1
            //};
            //Category cat6 = new Category
            //{
            //    Name = "Berrys",
            //    Parent = cat1
            //};
            //Category cat7 = new Category
            //{
            //    Name = "Potatoes",
            //    Parent = cat2
            //};
            //Category cat8 = new Category
            //{
            //    Name = "Beans",
            //    Parent = cat2
            //};
            //Category cat9 = new Category
            //{
            //    Name = "Tomatoes",
            //    Parent = cat2
            //};
            //Category cat10 = new Category
            //{
            //    Name = "Carrots",
            //    Parent = cat2
            //};
            //context.Categories.Add(cat1);
            //context.Categories.Add(cat2);
            //context.Categories.Add(cat3);
            //context.Categories.Add(cat4);
            //context.Categories.Add(cat5);
            //context.Categories.Add(cat6);
            //context.Categories.Add(cat7);
            //context.Categories.Add(cat8);
            //context.Categories.Add(cat9);
            //context.Categories.Add(cat10);
            //context.SaveChanges();


            //var products = new Faker<Product>();
            //products.RuleFor(x => x.Name, f => f.Commerce.ProductName());
            //products.RuleFor(x => x.Description, f => f.Commerce.ProductDescription());
            //products.RuleFor(x => x.Price, f => f.Random.Decimal(1, 100));
            //var cats = context.Categories.Select(x => x.Id).ToList();
            //products.RuleFor(x => x.CategoryId, f => f.PickRandom(cats));
            //var generateProducts = products.Generate(10);
            //context.Products.AddRange(generateProducts);


            //var customers = new Faker<Customer>();
            //customers.RuleFor(x => x.FirstName, f => f.Name.FirstName());
            //customers.RuleFor(x => x.LastName, f => f.Name.LastName());
            //customers.RuleFor(x => x.Username, f => f.Internet.UserName());
            //customers.RuleFor(x => x.Email, f => f.Internet.Email());
            //customers.RuleFor(x => x.Password, f => f.Internet.Password());
            //var files = context.Files.Select(x => x.Id).ToList();
            //customers.RuleFor(x => x.ImageId, f => f.PickRandom(files));
            //var generateCustomers = customers.Generate(10);
            //context.Customers.AddRange(generateCustomers);


            //var cpm = new Faker<CustomerPaymentMethod>();
            //var pm = context.PaymentMethods.Select(x => x.Id).ToList();
            //cpm.RuleFor(x => x.Customer, f => f.PickRandom(generateCustomers));
            //cpm.RuleFor(x => x.PaymentMethodId, f => f.PickRandom(pm));
            //cpm.RuleFor(x => x.CardNumber, f => f.Finance.CreditCardNumber());
            //cpm.RuleFor(x => x.Details, f => f.Lorem.Text());
            //var generateCPM = cpm.Generate(10);
            //context.CustomerPaymentMethods.AddRange(generateCPM);


            //var orders = new Faker<Order>();
            //var os = context.OrderStatuses.Select(x => x.Id).ToList();
            //orders.RuleFor(x => x.Customer, f => f.PickRandom(generateCustomers));
            //orders.RuleFor(x => x.OrderStatusId, f => f.PickRandom(os));
            //orders.RuleFor(x => x.Details, f => f.Lorem.Text());
            //var generateOrders = orders.Generate(10);
            //context.Orders.AddRange(generateOrders);


            //var invoices = new Faker<Invoice>();
            //var istatus = context.InvoiceStatuses.Select(x => x.Id).ToList();
            //invoices.RuleFor(x => x.Order, f => f.PickRandom(generateOrders));
            //invoices.RuleFor(x => x.InvoiceStatusId, f => f.PickRandom(istatus));
            //invoices.RuleFor(x => x.Details, f => f.Lorem.Text());
            //var generateInvoices = invoices.Generate(10);
            //context.Invoices.AddRange(generateInvoices);


            //var payments = new Faker<Payment>();
            //payments.RuleFor(x => x.Invoice, f => f.PickRandom(generateInvoices));
            //payments.RuleFor(x => x.Amount, f => f.Random.Decimal(100, 1000));
            //var generatePayments = payments.Generate(10);
            //context.Payments.AddRange(generatePayments);


            //var orderItems = new Faker<OrderItem>();
            //var ois = context.OrderItemStatuses.Select(x => x.Id).ToList();
            //orderItems.RuleFor(x => x.Product, f => f.PickRandom(generateProducts));
            //orderItems.RuleFor(x => x.Order, f => f.PickRandom(generateOrders));
            //orderItems.RuleFor(x => x.OrderItemStatusId, f => f.PickRandom(ois));
            //orderItems.RuleFor(x => x.Quantity, f => f.Random.Number(1, 20));
            //orderItems.RuleFor(x => x.Price, f => f.Random.Decimal(1, 100));
            //orderItems.RuleFor(x => x.Details, f => f.Lorem.Text());
            //var generateOrderItems = orderItems.Generate(10);
            //context.OrderItems.AddRange(generateOrderItems);


            //var shipments = new Faker<Shipment>();
            //shipments.RuleFor(x => x.Order, f => f.PickRandom(generateOrders));
            //shipments.RuleFor(x => x.Invoice, f => f.PickRandom(generateInvoices));
            //shipments.RuleFor(x => x.TrackingNumber, f => f.Commerce.Ean8());
            //shipments.RuleFor(x => x.Details, f => f.Lorem.Text());
            //var generateShipments = shipments.Generate(10);
            //context.Shipments.AddRange(generateShipments);


            //var shipitem = new Faker<ShipmentItem>();
            //var ship = context.Shipments.Select(x => x.Id).ToList();
            //var oi = context.OrderItems.Select(x => x.Id).ToList();
            //shipitem.RuleFor(x => x.ShipmentId, f => f.PickRandom(ship));
            //shipitem.RuleFor(x => x.OrderItemId, f => f.PickRandom(oi));
            //var generateShipItem = shipitem.Generate(10);
            //context.ShipmentItems.AddRange(generateShipItem);
            //context.SaveChanges();


            return Ok();
        }
    }
}
