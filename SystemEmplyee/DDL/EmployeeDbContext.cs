using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using SystemEmplyee.Models;

namespace SystemEmplyee.DDL
{
    public class EmployeeDbContext
    {
        private readonly string _myConnection;

        public EmployeeDbContext(IConfiguration configuration)
        {
            _myConnection = configuration.GetConnectionString("MyCon");
        }


        public void DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_DeleteEmploye", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateEmployee(int id,EmployeeDbModel dbModel)
        {
            SqlConnection con=new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", dbModel.Name);
            cmd.Parameters.AddWithValue("@Email", dbModel.Email);
            cmd.Parameters.AddWithValue("@Phone", dbModel.Phone);
            cmd.Parameters.AddWithValue("@Country", dbModel.CountId);
            cmd.Parameters.AddWithValue("@State", dbModel.StatId);
            cmd.Parameters.AddWithValue("@City", dbModel.CityId);
            cmd.Parameters.AddWithValue("@Dob", dbModel.Dob);
            cmd.Parameters.AddWithValue("@Salary", dbModel.Salary);
            cmd.Parameters.AddWithValue("@Department", dbModel.Dept);
            cmd.Parameters.AddWithValue("@Photo", dbModel.Photo);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
      
        }
        public EmployeeDbModel GetEmployeeDetailsById(int id)
        {
            EmployeeDbModel employeeDb = null;
            
            SqlConnection con = new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                employeeDb = new EmployeeDbModel();
                employeeDb.Name = sdr["Name"].ToString();
                employeeDb.Email = sdr["Email"].ToString();
                employeeDb.Phone = sdr["Phone"].ToString();
                employeeDb.Country = sdr["CountryName"].ToString();
                employeeDb.CountId = Convert.ToInt32(sdr["CountId"].ToString());
                employeeDb.State = sdr["StateName"].ToString();
                employeeDb.StatId = Convert.ToInt32(sdr["StateId"].ToString());
                employeeDb.City = sdr["CityName"].ToString();
                employeeDb.CityId= Convert.ToInt32(sdr["CityId"].ToString());
                employeeDb.Dob = Convert.ToDateTime(sdr["Dob"].ToString());
                employeeDb.Salary = Convert.ToDecimal(sdr["Salary"].ToString());
                employeeDb.Dept= Convert.ToInt32(sdr["DeptId"].ToString());
                employeeDb.Department = sdr["DepartmentName"].ToString();
                employeeDb.Photo = sdr["Photo"].ToString();
         
            }

            con.Close();
            return employeeDb;
        }

        public List<EmployeeDbModel> EmployeeList()
        {
            List<EmployeeDbModel> dblist = new List<EmployeeDbModel>();
            SqlConnection con = new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeList",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            while (sda.Read()) 
            { 
                EmployeeDbModel employeeDb=new EmployeeDbModel();
                employeeDb.Id = Convert.ToInt32(sda["Id"].ToString());
                employeeDb.Name= sda["Name"].ToString();
                employeeDb.Email = sda["Email"].ToString();
                employeeDb.Phone = sda["Phone"].ToString();
                employeeDb.Country = sda["CountryName"].ToString();
                employeeDb.State = sda["StateName"].ToString();
                employeeDb.City = sda["CityName"].ToString();
                employeeDb.Dob = Convert.ToDateTime(sda["Dob"].ToString());
                employeeDb.Salary = Convert.ToDecimal(sda["Salary"].ToString());
                employeeDb.Department = sda["DepartmentName"].ToString();
                employeeDb.Photo = sda["Photo"].ToString();
                dblist.Add(employeeDb);
                
            }
            return dblist;
        }
        

        public void CreateEmployee(EmployeeDbModel model)
        {
            SqlConnection con=new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_InsertEmployeeData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Phone", model.Phone);
            cmd.Parameters.AddWithValue("@Country",model.CountId);
            cmd.Parameters.AddWithValue("State", model.StatId);
            cmd.Parameters.AddWithValue("@City", model.CityId);
            cmd.Parameters.AddWithValue("@Dob", model.Dob);
            cmd.Parameters.AddWithValue("@Salary", model.Salary);
            cmd.Parameters.AddWithValue("@Department", model.Dept);
            cmd.Parameters.AddWithValue("@Photo", model.Photo);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<DepartmentDbModel> DepartmentList()
        {
            List<DepartmentDbModel> departmentDbModels = new List<DepartmentDbModel>();
            SqlConnection con = new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_GetDepartments",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                DepartmentDbModel dbModel = new DepartmentDbModel();
                dbModel.DepartmentId = Convert.ToInt32(sdr["DeptId"].ToString());
                dbModel.DepartmentName = sdr["DepartmentName"].ToString();
                departmentDbModels.Add(dbModel);
            }
            return departmentDbModels;
        }

        public List<CountryDbModel> CountryList()
        {
            List<CountryDbModel> countryDbModels = new List<CountryDbModel>();

            SqlConnection con=new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_GetCountry", con);
            cmd.CommandType=CommandType.StoredProcedure;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CountryDbModel dbmodel = new CountryDbModel();
                dbmodel.CountryId = Convert.ToInt32(reader["CountryId"].ToString());
                dbmodel.CountryName = reader["CountryName"].ToString();
                countryDbModels.Add(dbmodel);
            }
            return countryDbModels;
        }

        public List<StateDbModel> StateList(int countId)
        {
            List<StateDbModel> stateDbModels = new List<StateDbModel>();

            SqlConnection con = new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_State",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountId",countId);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                StateDbModel stateDb = new StateDbModel();
                stateDb.StateId = Convert.ToInt32(sdr["StateId"].ToString());
                stateDb.StateName = sdr["StateName"].ToString();
                stateDbModels.Add(stateDb);
            }
            return stateDbModels;
        }

        public List<CityDbModel> CityList(int cityID)
        {
            List<CityDbModel> cityDbModels = new List<CityDbModel>();

            SqlConnection con=new SqlConnection(_myConnection);
            SqlCommand cmd = new SqlCommand("sp_City", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateID", cityID);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read()) 
            {
                CityDbModel cityDb = new CityDbModel();
                cityDb.CityId = Convert.ToInt32(sdr["CityId"]);
                cityDb.CityName = sdr["CityName"].ToString();
                cityDbModels.Add(cityDb);

            }
            return cityDbModels;
        }
    }
}
