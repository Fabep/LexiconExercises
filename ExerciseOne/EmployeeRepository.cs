namespace ExerciseOne;

public class EmployeeRepository
{
    private Dictionary<int, Employee> EmployeeRegistry { get; }
    public EmployeeRepository()
    {
        EmployeeRegistry = [];
    }

    public void AddEmployee(Employee employee)
    {
        EmployeeRegistry.Add(employee.Id, employee);
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return EmployeeRegistry.Values;
    }
    public int GetNextId => EmployeeRegistry.Count + 1;
}
