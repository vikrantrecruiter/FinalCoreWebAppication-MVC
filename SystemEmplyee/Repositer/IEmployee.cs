using SystemEmplyee.Models;

namespace SystemEmplyee.Repositer
{
    public interface IEmployee
    {
        List<CountryDbModel> CountryList();

        List<StateDbModel> StateList(int countid);

        List<CityDbModel> CityList(int statid);

        List<DepartmentDbModel> DepartmentList();

         void CreateEmployee(EmployeeDbModel employeeDb);

        List<EmployeeDbModel> EmployeeList();

        EmployeeDbModel GetEmployeeDetailsById(int id);

        void UpdateEmployee(int id, EmployeeDbModel dbModel);

        void DeleteEmployee(int id);


    }
}
