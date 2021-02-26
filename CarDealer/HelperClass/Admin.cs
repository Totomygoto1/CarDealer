using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CarDealer.HelperClass
{
    public class Admin
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-E1IQVN5\\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");

        public Admin()
        {

        }

        public DataTable ViewData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "spViewAllCars";
            cmd.CommandType = CommandType.StoredProcedure;
            
            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            con.Close();

            return dt;
        }

        public void AddNewCar(string FullName, string Colour, string ImageURL, string ModelYear)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "spAddCar";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter workparameter1 = new SqlParameter();
            workparameter1 = cmd.Parameters.Add("@FullName", SqlDbType.VarChar);
            workparameter1.Value = FullName;

            SqlParameter workparameter2 = new SqlParameter();
            workparameter2 = cmd.Parameters.Add("@Colour", SqlDbType.VarChar);
            workparameter2.Value = Colour;

            SqlParameter workparameter3 = new SqlParameter();
            workparameter3 = cmd.Parameters.Add("@ImageURL", SqlDbType.VarChar);
            workparameter3.Value = ImageURL;

            int modelYear = Int32.Parse(ModelYear);
            SqlParameter workparameter4 = new SqlParameter();
            workparameter4 = cmd.Parameters.Add("@ModelYear", SqlDbType.Int);
            workparameter4.Value = ModelYear;

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
            
        }

        public DataTable UpdateCar(string CarId, string FullName, string Colour, string ImageURL, string ModelYear)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "spUpdateCar";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter workparameter1 = new SqlParameter();
            workparameter1 = cmd.Parameters.Add("@FullName", SqlDbType.VarChar);
            workparameter1.Value = FullName;

            SqlParameter workparameter2 = new SqlParameter();
            workparameter2 = cmd.Parameters.Add("@Colour", SqlDbType.VarChar);
            workparameter2.Value = Colour;

            SqlParameter workparameter3 = new SqlParameter();
            workparameter3 = cmd.Parameters.Add("@ImageURL", SqlDbType.VarChar);
            workparameter3.Value = ImageURL;

            int modelYear = Int32.Parse(ModelYear);
            SqlParameter workparameter4 = new SqlParameter();
            workparameter4 = cmd.Parameters.Add("@ModelYear", SqlDbType.Int);
            workparameter4.Value = ModelYear;

            int CarID = Int32.Parse(CarId);
            SqlParameter workparameter5 = new SqlParameter();
            workparameter5 = cmd.Parameters.Add("@CarID", SqlDbType.Int);
            workparameter5.Value = ModelYear;

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            con.Close();

            return dt;

        }


        public DataTable DeleteCar(string CarId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "spDeleteCar";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CarID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = CarId;

            cmd.Parameters.Add(parameter);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            con.Close();

            return dt;

        }



    }
}