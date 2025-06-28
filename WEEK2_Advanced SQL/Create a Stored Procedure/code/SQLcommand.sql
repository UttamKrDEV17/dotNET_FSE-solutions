-- 1. Create Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- 2. Create Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1), -- Using IDENTITY for auto-incrementing EmployeeID
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Sample Data for Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

-- Sample Data for Employees
-- Note: EmployeeID is now auto-incremented, so we don't insert it explicitly.
SET IDENTITY_INSERT Employees ON; -- Temporarily enable identity insert for the provided sample data if EmployeeID is specified
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');
SET IDENTITY_INSERT Employees OFF; -- Disable identity insert after inserting initial data

-- Exercise 1: Create a Stored Procedure to Retrieve Employee Details by Department

IF OBJECT_ID('sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeesByDepartment;
GO

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    -- Select all columns from the Employees table
    -- Filter by the provided DepartmentID
    -- Join with Departments table to include DepartmentName for clarity
    SELECT
        E.EmployeeID,
        E.FirstName,
        E.LastName,
        D.DepartmentName,
        E.Salary,
        E.JoinDate
    FROM
        Employees AS E
    INNER JOIN
        Departments AS D ON E.DepartmentID = D.DepartmentID
    WHERE
        E.DepartmentID = @DepartmentID;
END;
GO

-- Exercise 2: Create a Stored Procedure to Insert a New Employee


IF OBJECT_ID('sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertEmployee;
GO

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    -- Insert a new row into the Employees table
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);

    -- Optionally, you can return the EmployeeID of the newly inserted row
    SELECT SCOPE_IDENTITY() AS NewEmployeeID;
END;
GO