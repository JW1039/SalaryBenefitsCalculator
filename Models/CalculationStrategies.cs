using System.Diagnostics;

namespace LeasePlus_DevTest.Models
{
    /// <summary>
    /// Interface defining the strategy for calculating an employee's salary benefit limit.
    /// </summary>
    public interface ICalculationStrategy
    {
        public decimal Calculate(Employee employee);
    }

    /// <summary>
    /// Strategy for calculating the salary limit for a corporate employee.
    /// </summary>
    public class CorporateStrategy : ICalculationStrategy
    {
        public decimal Calculate(Employee employee)
        {
            /// <summary>
            /// Calculates the salary limit for a corporate employee, adjusting for threshold and hours worked.
            /// </summary>
            /// <param name="employee">The employee for whom the salary is being calculated.</param>
            /// <returns>The calculated salary limit for the corporate employee.</returns>
            if (employee.EmploymentType != EmploymentType.Casual)
            {
                const decimal threshold = 100000;
                decimal limit = 0;

                if (employee.Salary > threshold)
                {
                    limit = threshold * 0.01m + (employee.Salary - threshold) * 0.001m;
                }
                else
                {
                    limit = employee.Salary * 0.01m;
                }

                Debug.WriteLine($"{employee.HoursWorked / 38m} | {employee.Salary}");

                if (employee.EmploymentType == EmploymentType.PartTime)
                {
                    limit = employee.HoursWorked / 38m * limit;
                }
                return limit;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Strategy for calculating the salary limit for a hospital employee.
    /// </summary>
    public class HospitalStrategy : ICalculationStrategy
    {
        /// <summary>
        /// Calculates the salary limit for a hospital employee, adjusting for threshold, education, and employment type.
        /// </summary>
        /// <param name="employee">The employee for whom the salary limit is being calculated.</param>
        /// <returns>The calculated salary limit for the hospital employee.</returns>
        public decimal Calculate(Employee employee)
        {
            const decimal threshold = 10000;
            decimal limit = employee.Salary * 0.2m;

            if (limit < threshold)
            {
                limit = threshold;
            }
            else if (limit > 30000)
            {
                limit = 30000;
            }

            if (employee.IsEducated)
            {
                limit += 5000;
            }

            if (employee.EmploymentType == EmploymentType.FullTime)
            {
                limit = limit * 1.095m;
                limit += employee.Salary * 0.012m;
            }

            return limit;
        }
    }

    /// <summary>
    /// Strategy for calculating the salary limit for a PBI employee.
    /// </summary>
    public class PBIStrategy : ICalculationStrategy
    {
        /// <summary>
        /// Calculates the salary limit for a PBI employee, adjusting based on education and employment type.
        /// </summary>
        /// <param name="employee">The employee for whom the salary is being calculated.</param>
        /// <returns>The calculated salary limit for the PBI employee.</returns>
        public decimal Calculate(Employee employee)
        {
            decimal limit = 0;
            const decimal threshold = 50000;

            if (employee.EmploymentType == EmploymentType.Casual)
            {
                limit = 0.1m * employee.Salary;
            }
            else
            {
                limit = 0.3255m * employee.Salary;
                if (limit > threshold)
                {
                    limit = threshold;
                }
            }

            if (employee.IsEducated)
            {
                limit += 2000 + 0.01m * employee.Salary;
            }

            if (employee.EmploymentType == EmploymentType.PartTime)
            {
                limit *= 0.8m;
            }

            return limit;
        }
    }

}
