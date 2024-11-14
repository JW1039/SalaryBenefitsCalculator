namespace LeasePlus_DevTest.Models
{
    /// <summary>
    /// Represents an employee with properties and a method to calculate salary benefit limit based on company type.
    /// </summary>
    public class Employee
    {
        public CompanyType CompanyType { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public bool IsEducated { get; set; }

        public int HoursWorked { get; set; } = 38;

        public decimal Salary { get; set; }

        /// <summary>
        /// Calculates the employee's salary based on the current company type.
        /// </summary>
        /// <returns>The calculated salary, rounded to the nearest decimal.</returns>
        public decimal CalculateSalary()
        {
            // declare instance of calculator strategy based on company type
            ICalculationStrategy strategy = GetStrategy();
            return Math.Round(strategy.Calculate(this));
        }

        /// <summary>
        /// Selects the appropriate calculation strategy based on the employee's company type.
        /// </summary>
        /// <returns>An instance of a class that implements the <see cref="ICalculationStrategy"/> interface.</returns>
        private ICalculationStrategy GetStrategy()
        {
            // select strategy based on company type
            return CompanyType switch
            {
                CompanyType.Corporate => new CorporateStrategy(),
                CompanyType.Hospital => new HospitalStrategy(),
                CompanyType.PBI => new PBIStrategy()
            };
        }

    }
}