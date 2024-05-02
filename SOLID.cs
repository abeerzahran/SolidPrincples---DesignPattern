/// <summary>
/// VIOLATE SOLID
/// </summary>
public class ECommerceSystem
{
    private List<Product> products = new List<Product>();
    private List<Order> orders = new List<Order>();
    public void AddProduct(string name, decimal price, int quantity)
    {
        products.Add(new Product
        {
            Name = name,
            Price = price,
            Quantity =
        quantity
        });
    }
    public void PlaceOrder(string customerName, List<int> productIds, string paymentMethod)
    {
        decimal totalCost = 0;
        List<Product> orderedProducts = new List<Product>();
        foreach (int productId in productIds)
        {
            Product product = products.Find(p => p.Id == productId);
            if (product != null && product.Quantity > 0)
            {
                orderedProducts.Add(product);
                totalCost += product.Price;
                product.Quantity--;
            }
        }
        if (orderedProducts.Count > 0)
        {
            if (paymentMethod == "CreditCard")
            {
                ProcessCreditCardPayment(totalCost);
            }
            else if (paymentMethod == "PayPal")
            {
                ProcessPayPalPayment(totalCost);
            }
            Order order = new Order
            {
                CustomerName = customerName,
                Products = orderedProducts,
                TotalCost = totalCost
            };
            orders.Add(order);
            SendOrderConfirmationEmail(order);
        }
    }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
public class Order
{
    public string CustomerName { get; set; }
    public List<Product> Products { get; set; }
    public decimal TotalCost { get; set; }
}


//////////////////////////////////////////// REFACTORING/////////////////////////////////////////////


////////////////////////////////////////// INTERFACES////////////////////////////////////
////Introduce Interfaces: Define interfaces like IUnitOfWork, IOrderRepository, IProductRepository, 
///IPayment, and INotification to abstract different responsibilities.
////
public interface IUnitOfWork
{

}
public interface IOrderRepository
{
    public void AddProduct(string name, decimal price, int quantity);
}
public interface IProductRepository
{
    public void AddProduct(string name, decimal price, int quantity);
    public Product GetProductById(int id);
}
public interface IPayment
{
    ProcessPayment(decimal totalCost);
}

public interface INotification
{
    SendOrderConfirmationEmail(Order order);
}

////////////////////////////// UNIT OF WORK //////////////////////////////////////
///
/// Introduce UnitOfWork to manage the overall unit of work and track changes to products and orders.
public class UnitOfWork : IUnitOfWork
{
    private List<Product> products;
    private List<Order> orders;

    public List<Product> Products
    {
        get
        {
            return products ?? products = new List<Product>();
        }
    }
    public List<Order> Orders
    {
        get
        {
            return orders ?? orders = new List<order>();
        }
    }
}





/// //////////////////////////////////////// REPOSITORY //////////////////////////////////////////////////////
/// 
///Implement Repository Pattern: Refactor to use repository pattern for data access. 
///Separate OrderRepository and ProductRepository to handle operations related to orders and 
///products respectively.
public class ProductRepository : IProductRepository
{
    public IUnitOfWork unitOfWork
    public ProductRepository(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    public void AddProduct(string name, decimal price, int quantity)
    {
        products.Add(new Product
        {
            Name = name,
            Price = price,
            Quantity =
        quantity
        });
    }
    public Product GetProductById(int id)
    {
        return unitOfWork.Products.Find(id);
    }
}

public class OrderRepository : IOrderRepository
{
    public IUnitOfWork unitOfWork
    public IProductRepository productRepo;
    public PaymentService paymentService;
    public INotification notification;
    public OrderRepository(IUnitOfWork _unitOfWork, IProductRepository _productRepo, PaymentService _paymentService, INotification _notification)
    {
        unitOfWork = _unitOfWork;
        productRepo = _productRepo;
        paymentService = _paymentService;
        notification = _notification;
    }

    public void PlaceOrder(string customerName, List<int> productIds, string paymentMethod)
    {
        decimal totalCost = 0;
        List<Product> orderedProducts = new List<Product>();
        foreach (int productId in productIds)
        {
            Product product = productRepo.GetProductById(productId);
            if (product != null && product.Quantity > 0)
            {
                orderedProducts.Add(product);
                totalCost += product.Price;
                product.Quantity--;
            }
        }
        if (orderedProducts.Count > 0)
        {
            PaymentService.PaymentProcess(totalCost);

            Order order = new Order
            {
                CustomerName = customerName,
                Products = orderedProducts,
                TotalCost = totalCost
            };
            unitOfWork.Orders.Add(order);
            notification.SendOrderConfirmationEmail(order);


        }
    }
}

/// /////////////////////////////////// MODELS //////////////////////////////////////////
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class Order
{
    public string CustomerName { get; set; }
    public List<Product> Products { get; set; }
    public decimal TotalCost { get; set; }
}


/// Implement PayPal and CreditCard classes which implement the IPayment interface,
/// each handling payment processing differently.

public class PayPal : IPayment
{
    public decimal TotalCost;
    public ProcessPayment(TotalCost)
    {
        //code
    }

}

public class CreditCard : IPayment
{
    public decimal TotalCost;
    public ProcessPayment(TotalCost)
    {
        //code
    }

}


/// Define Notification class implementing INotification interface for sending order confirmation emails.

public class Notification : INotification
{
    SendOrderConfirmationEmail(Order order)
    {
        //code
    }
}

/// ///////////////////////////////////SERVICES//////////////////////////////////////
/// 
/// Create PaymentService to handle payment processing. This class will utilize different payment methods 
/// through the IPayment interface, allowing for easy extension.
public class PaymentService
{
    public IPayment payment;
    public PaymentService(IPayment _payment)
    {
        payment = _payment;
    }
    public void ProcessPayment(decimal amount)
    {
        payment.ProcessPayment(amount);
    }

}



