/// <summary>
/// Violate the open Closed Principle
/// if I want to add another payment method I will modify the enum and the proccessPayment method
/// </summary>
public class PaymentProcessor
{
    public void ProcessPayment(PaymentType type, double amount)
    {
        switch (type)
        {
            case PaymentType.CreditCard:
                Process credit card payment
            break;
            case PaymentType.PayPal:
                Process PayPal payment
            break;
            case PaymentType.BankTransfer:
                Process bank transfer payment
            break; Add more cases for other payment types
            }
    }
}
public enum PaymentType
{
    CreditCard,
    PayPal,
    BankTransfer
}

/// <summary>
/// Solution
/// </summary>
/// 

//Implement An Interface with the ProcessPayment function (common function)
//make each class implement this interface to force it implement the this function
//If I want to add another payment method I will declare another class that implement the same interface 
interface IPayment
{
    public void ProcessPayment(double amount);
}

class CreditCard : IPayment
{
    public void ProcessPayment(double amount)
    {

    }
}
class PayPal : IPayment
{
    public void ProcessPayment(double amount)
    {

    }
}

class BankTransfer : IPayment
{
    public void ProcessPayment(double amount)
    {

    }
}