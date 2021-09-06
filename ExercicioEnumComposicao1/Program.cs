using System;
using System.Globalization;
using ExercicioEnumComposicao1.Entities;
using ExercicioEnumComposicao1.Entities.Enums;

namespace ExercicioEnumComposicao1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter department's name: ");
                string deptName = Console.ReadLine();

                Console.WriteLine("\nEnter worker data:");
                Console.Write("Name: ");
                string workerName = Console.ReadLine();
                Console.Write("Level (Junior/MidLevel/Senior): ");
                WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
                Console.Write("Base salary: ");
                double workerBSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Department department = new Department(deptName);
                Worker worker = new Worker(workerName, workerLevel, workerBSalary, department);

                Console.Write("\nHow many contracts to this worker? ");
                int n = int.Parse(Console.ReadLine());
                
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"\nEnter #{i} contract data:");
                    Console.Write("Date (DD/MM/YYYY): ");
                    DateTime contractDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Value per hour: ");
                    double contractValuePH = double.Parse(Console.ReadLine());
                    Console.Write("Duration (hours): ");
                    int contractHours = int.Parse(Console.ReadLine());

                    HourContract contract = new HourContract(contractDate, contractValuePH, contractHours);
                    worker.AddContract(contract);
                }

                Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
                string[] monthAndYear = Console.ReadLine().Split('/');

                int month = int.Parse(monthAndYear[0]);
                int year = int.Parse(monthAndYear[1]);

                Console.WriteLine($"Name: {worker.Name}\nDepartment: {worker.Department.Name}\nIncome for {monthAndYear[0]}/{monthAndYear[1]}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");                
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro - [{0}]", ex.Message);
            }
            Console.WriteLine();
        }
    }
}