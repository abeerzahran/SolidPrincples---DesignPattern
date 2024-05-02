/// <summary>
/// Violate the LSP
/// </summary>
public class Account
{
    public decimal Balance { get; protected set; }
    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public virtual void Withdraw(decimal amount)
    {
        if (Balance  amount) {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient balance.");
        }
    }
}
public class SavingsAccount : Account
{
    public decimal InterestRate { get; set; }
    public override void Withdraw(decimal amount)
    {
        Impose a withdrawal fee amount += 5.0m; base.Withdraw(amount);
    }
}


/// <summary>
/// Solution
/// </summary>
/// 
//parent Abstract class have the common properties between the two classes
abstract class BaseAccount
{
    public decimal Balance { get; protected set; }
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
    //this method has different implementation for each Type (class)
    public abstract void Withdraw(decimal amount);
}

public class Account : BaseAccount
{
    //inherted the properties of the base Account
    //override the withdraw 
    public override void Withdraw(decimal amount)
    {
        if (Balance  amount) {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient balance.");
        }
    }
}

public class SavingsAccount : BaseAccount
{
    //inherted the properties of the base Account
    //override the withdraw 
    public decimal InterestRate { get; set; }
    public override void Withdraw(decimal amount)
    {
        Impose a withdrawal fee amount += 5.0m; base.Withdraw(amount);
    }
}