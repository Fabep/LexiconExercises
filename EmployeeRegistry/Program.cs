using EmployeeRegistry;


internal class Program
{
    private const string EXIT_MESSAGE = "Exiting...";
    private const string CONTINUE_MESSAGE = "Press any key to continue.";
    private static void Main(string[] args)
    {
        EmployeeRepository employeeRepository = new();
        EmployeeDisplayService employeeDisplayService = new(employeeRepository);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(Menu);

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input == 1)
                {
                    var newEmployee = employeeDisplayService.CreateEmployee();
                    employeeRepository.AddEmployee(newEmployee);
                }
                else if (input == 2)
                {
                    employeeDisplayService.DisplayEmployees();
                }
                else if (input == 3)
                {
                    Console.WriteLine(EXIT_MESSAGE);
                    break;
                }
                else
                    Console.WriteLine(GetInvalidOptionMessage("Input out of range."));
            }
            else
                Console.WriteLine(GetInvalidOptionMessage("Input must be a number."));

            Console.WriteLine(CONTINUE_MESSAGE);
            Console.ReadKey();
        }
    }


    private static string GetInvalidOptionMessage(string errorMessage) => $"Invalid option. {errorMessage}{Environment.NewLine}Press any key to continue.";
    private static readonly string Menu = 
        $"1. Add Employee{Environment.NewLine}2. List Employees{Environment.NewLine}3. Exit{Environment.NewLine}";
}
