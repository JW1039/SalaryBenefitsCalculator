# Salary Benefit Calculator

This application uses ASP.NET paired with a Model-View-Controller architecture to implement a full stack application for calculating employee salary benefits given the provided specifications.\
It also implements the **strategy pattern** in [CalculationStrategies.cs](./Models/CalculationStrategies.cs) to store different calculation methods based on the company type.\
This architecture flexibly allows for new companies to be implemented by simply adding a new calculation strategy and company enumerator.

**The relevant files are:**
## Models
- [Employee.cs](./Models/Employee.cs): Contains employee attributes used for calculation as well as references to the calculation methods.
- [CalculationStrategies.cs](./Models/CalculationStrategies.cs): Contains methods for calculating each company type benefit limit all inheriting a common ICalculationStrategy interface.
- [CompanyType.cs](./Models/CompanyType.cs): An enumerator for the company type (corporate, hospital, PBI).
- [EmploymentType.cs](./Models/EmploymentType.cs): An enumerator for the employment type (full time, part time, casual).
## Controller/View
-  [EmployeeController.cs](./Controllers/EmployeeController.cs): Links [Employee.cs](./Models/Employee.cs) routes to the [Index.cshtml](./Views/Employee/Index.cshtml) view.