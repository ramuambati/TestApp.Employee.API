SELECT 
    P.WorkerID, 
    P.FirstName, 
    P.LastName,
    P.Address1,
    CASE 
        WHEN E.WorkerId IS NOT NULL THEN 'Employee' 
        WHEN M.WorkerId IS NOT NULL THEN 'Manager' 
        WHEN S.WorkerId IS NOT NULL THEN 'Supervisor' 
    END as WorkerType,
    COALESCE(e.PayPerHour, m.AnnualSalary, s.AnnualSalary) as PayPerHour,
    COALESCE(m.AnnualSalary, s.AnnualSalary) as AnnualSalary,
    COALESCE(m.MaxExpenseAmount, null) as MaxExpenseAmount
FROM Worker P
LEFT JOIN Employee E ON E.WorkerId = P.WorkerId
LEFT JOIN Manager M ON M.WorkerId = P.WorkerId
LEFT JOIN Supervisor S ON S.WorkerId = P.WorkerId;


