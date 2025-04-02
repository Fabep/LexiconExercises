namespace EmployeeRegistry;

public class Employee
{
    public int Id { get; }
    public string Name { get; set; } = null!;
    public decimal Salary { get; set; }
    public Employee(int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Name: {Name}{Environment.NewLine}Salary: {Salary}";
    }
}
