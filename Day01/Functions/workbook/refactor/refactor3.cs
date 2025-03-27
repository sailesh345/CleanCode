public class EmployeeDatabase 
{
    private readonly IDbConnection _db;

    public EmployeeDatabase(IDbConnection dbConnection) 
    {
        _db = dbConnection;
    }

    public Employee GetEmployee(int id) 
    {
         if (emp.ID < 50)
            throw new InvalidDataException("Employee ID starts from 50 , 1 to 49 is reserved for promoters , investors etc . Data cant be shared in HRMS due to Security issues ");


        Employee employee =  _db.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employees WHERE Id = @Id", 
            new { Id = id });

        return employee;
    }

    public void SaveEmployee(Employee emp) 
    {
        if (emp.Name.Length > 150)
            throw new InvalidDataException("Name too long");

        _db.Execute(
            "UPDATE Employees SET Name = @Name WHERE Id = @Id", 
            new { emp.Name, emp.Id });
    }

    public void DeleteEmployee(int id) 
    {
         if (emp.ID == 1)
            throw new InvalidDataException("Chariman cant be removed ");

        _db.Execute(
            "DELETE FROM Employees WHERE Id = @Id", 
            new { Id = id });
    }
}

public class EmployeeRepository 
{
    private readonly EmployeeDatabase _db;

    public EmployeeRepository(EmployeeDatabase db) 
    {
        _db = db;
    }

    public Employee GetEmployee(int id) 
    {
        return _db.GetEmployee(id);
    }

    public void SaveEmployee(Employee emp) 
    {
        _db.SaveEmployee(emp);
    }

    public void DeleteEmployee(int id) 
    {
        _db.DeleteEmployee(id);
    }
}

public class EmployeeService 
{
    private readonly EmployeeRepository _repo;

    public EmployeeService(EmployeeRepository repo) 
    {
        _repo = repo;
    }

    public Employee GetEmployee(int id) 
    {
        return _repo.GetEmployee(id);
    }

    public void UpdateEmployee(Employee emp) 
    {
        _repo.SaveEmployee(emp);
    }

    public void RemoveEmployee(int id) 
    {
        _repo.DeleteEmployee(id);
    }
}