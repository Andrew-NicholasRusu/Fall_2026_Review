public class Employee 
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<double> Salaries { get; set; }

    public static List<Employee> Employees { get; } = new List<Employee>
    {
        new Employee { Id = 1001, Name = "Alice Martin", Salaries = new List<double> { 52000, 54000, 56500 } },
        new Employee { Id = 1002, Name = "Brian Chen", Salaries = new List<double> { 58000, 60500, 63000 } },
        new Employee { Id = 1003, Name = "Clara Patel", Salaries = new List<double> { 61000, 64000, 67500 } },
        new Employee { Id = 1004, Name = "David Wilson", Salaries = new List<double> { 49000, 51500, 54000 } },
        new Employee { Id = 1005, Name = "Emma Garcia", Salaries = new List<double> { 70000, 73500, 77000 } }
    };

    public static void DisplayNamesAndFirstSalaries()
    {
        var employees = Employees;
        var result = employees.Select(employee => new
        {
            employee.Name,
            FirstSalary = employee.Salaries.First()
        });

        foreach (var employee in result)
        {
            Console.WriteLine($"{employee.Name}: {employee.FirstSalary}");
        }
    }

    public static void DisplayEmployeesWithSalaryAtLeast5000()
    {
        // Salaries are ordered from oldest salary to newest salary.
        var result = Employees
            .Where(employee => employee.Salaries.Any(salary => salary >= 5000))
            .Select(employee => employee.Name);

        foreach (var employeeName in result)
        {
            Console.WriteLine(employeeName);
        }
    }
}
