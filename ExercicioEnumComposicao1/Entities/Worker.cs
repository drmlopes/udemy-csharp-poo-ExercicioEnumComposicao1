using System.Collections.Generic;
using ExercicioEnumComposicao1.Entities.Enums;

namespace ExercicioEnumComposicao1.Entities
{
    class Worker
    {
        public string Name { get; private set; }
        public WorkerLevel Level { get; private set; }
        public double BaseSalary { get; private set; }

        public Department Department { get; private set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double income = BaseSalary;

            foreach (HourContract obj in Contracts)
            {
                if ((obj.Date.Year == year) && (obj.Date.Month == month))
                    income += obj.TotalValue();
            }
            return income;
        }
    }
}