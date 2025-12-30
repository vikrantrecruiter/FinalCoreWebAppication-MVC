using SystemEmplyee.DDL;
using SystemEmplyee.Models;

namespace SystemEmplyee.Repositer
{
    public class EmployeeRepositer :IEmployee
    {

        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepositer(EmployeeDbContext employeeDb)
        {
            _dbContext = employeeDb;
        }

        public List<CountryDbModel> CountryList()
        {
            return _dbContext.CountryList();
        }

        public void UpdateEmployee(int id, EmployeeDbModel dbModel)
        {
            _dbContext.UpdateEmployee(id, dbModel);
        }
        public List<EmployeeDbModel> EmployeeList()
        {
            return _dbContext.EmployeeList();
        }

        public EmployeeDbModel GetEmployeeDetailsById(int id)
        {
            return _dbContext.GetEmployeeDetailsById(id);
        }

        public  List<StateDbModel> StateList(int countId)
        {
            return _dbContext.StateList(countId);
        }

        public List<CityDbModel> CityList(int cityID)
        {
            return _dbContext.CityList(cityID);
        }

        public List<DepartmentDbModel> DepartmentList()
        {
            return _dbContext.DepartmentList();
        }

        public void CreateEmployee(EmployeeDbModel employee)
        {
             _dbContext.CreateEmployee(employee);
        }

        public void DeleteEmployee(int id) 
        {
            _dbContext.DeleteEmployee(id);
        }
     
    }
}
