-- SECTION 1: CREATE THE TABLES AND INSERT SAMPLE DATA (if not already done)
-- You can skip this section if your tables are already set up.

-- Create the Departments Table
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Insert Sample Data into Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');

-- Create the Employees Table
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL DROP TABLE dbo.Employees;
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10, 2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- Insert Sample Data into Employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01');

PRINT 'Tables created and data inserted.';


-- SECTION 2: CREATE THE SCALAR FUNCTION fn_CalculateAnnualSalary
-- Drop the function if it already exists to avoid errors during creation
IF OBJECT_ID('dbo.fn_CalculateAnnualSalary') IS NOT NULL
BEGIN
    DROP FUNCTION dbo.fn_CalculateAnnualSalary;
END
GO

-- Create the scalar function
CREATE FUNCTION dbo.fn_CalculateAnnualSalary
(
    @EmployeeID INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @AnnualSalary DECIMAL(10, 2);

    SELECT @AnnualSalary = Salary * 12
    FROM Employees
    WHERE EmployeeID = @EmployeeID;

    RETURN @AnnualSalary;
END;
GO
PRINT 'Function dbo.fn_CalculateAnnualSalary created.';


-- SECTION 3: EXECUTE THE FUNCTION AND VERIFY THE RESULT (Exercise 7)
-- 1. Execute the fn_CalculateAnnualSalary function for an employee with EmployeeID = 1.
SELECT dbo.fn_CalculateAnnualSalary(1) AS AnnualSalaryForEmployee1;

-- 2. Verify the result (Manually check against sample data)
-- For EmployeeID 1, Salary is 5000.00.
-- Annual Salary = 5000.00 * 12 = 60000.00.
PRINT 'Verification: Expected result for EmployeeID 1 is 60000.00.';