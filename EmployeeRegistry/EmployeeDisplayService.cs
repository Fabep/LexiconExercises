namespace EmployeeRegistry;

public class EmployeeDisplayService
{
    private readonly EmployeeRepository _employeeRepository;
    public EmployeeDisplayService(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public void DisplayEmployees()
    {
        foreach (var employee in _employeeRepository.GetAllEmployees())
            Console.WriteLine(employee);
    }
    public Employee CreateEmployee()
    {
        var name = PromptForString("Employee Name: ", x => string.IsNullOrWhiteSpace(x), "Employee name can't be empty.");
        var salary = PromptForDecimal("Employee Salary: ", x => x <= 0, "Employee salary can't be less than or equal to 0.");
        Employee employee = new(_employeeRepository.GetNextId, name, salary);

        return employee;
    }

    private static string PromptForString(string prompt, Func<string, bool>? customValidation, string? errorMessage = "")
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (input is null)
                Console.WriteLine("Invalid input. Input is null.");
            else if (customValidation is not null && customValidation(input))
                Console.WriteLine($"Invalid input. {errorMessage}");
            else 
                return input;
        }
    }

    private static decimal PromptForDecimal(string prompt, Func<decimal, bool>? customValidation, string? errorMessage = "")
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (input is null)
                Console.WriteLine("Invalid input. Input is null.");
            else if (!decimal.TryParse(input, out var result))
                Console.WriteLine("Invalid input. Unable to parse input as decimal.");
            else if (customValidation is not null && customValidation(result))
                Console.WriteLine($"Invalid input. {errorMessage}");
            else
                return result;
        }
    }
}
