/// <summary>
/// violate the single responsibility
/// </summary>
//
//the class has multiple responsibilities 
//1 Employee identify
//2 Calculate YearlySalary
//3 Generate Report
//4 SendNotification
public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
    public decimal CalculateYearlySalary()
    {
        return Salary * 12;
    }
    public void GenerateReport(string reportType)
    {
        //Code to generate report based on reportType 
    }
    public void SendNotification(string recipient, string message)
    {
        //Code to send email notification
    }
}

//solutions
// separate each responsibility in a class
public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
}
public class YearlySalary
{
    public decimal CalculateYearlySalary()
    {
        return Salary * 12;
    }
}
public class ReportGeneration
{
    public void GenerateReport(string reportType)
    {
        //Code to generate report based on reportType 
    }
}
public class notification
{
    public void SendNotification(string recipient, string message)
    {
        //Code to send email notification
    }
}



