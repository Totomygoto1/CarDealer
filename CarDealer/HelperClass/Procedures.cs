using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CarDealer.HelperClass
{

    public class Procedures
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-E1IQVN5\\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");

        public Procedures()
        {

        }

        public DataTable sqlCommandStoredProcedure(string sp, string param)
        {
 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;

            if (param.Length > 0)
            {

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@query";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = param;

                cmd.Parameters.Add(parameter);
            }

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            con.Close();

            return dt;

        }

        public DataTable searchCars(string make, string colour, string modelyear)
        {
            DataTable dt = new DataTable();

            int x = 0;

            string query = "";
            query += " select ImageURL,FullName,Colour,ModelYear,Make,Fuel,Mileage,Region,Transmission,Horsepower,Shaft,Body from Cars where ";

            if (make.Length > 0)
            {
                query += " Make = '" + make + "'";
                x = 1;
            }
            if (colour.Length > 0)
            {
                if (x == 1)
                {
                    query += " and ";
                }
                query += " Colour = '" + colour + "'";
                x = 2;
            }
            if (modelyear.Length > 0)
            {
                if (x == 2 || x == 1)
                {
                    query += " and ";
                }
                query += " ModelYear = " + modelyear + " ";
                x = 3;
            }


            if (x == 1 || x == 2 || x == 3)
            {
                dt = sqlCommandStoredProcedure("spGetSelectedCars", query);
            }
            else
            {
                dt = sqlCommandStoredProcedure("spGetAllCars", "");
            }

            return dt;
        }

        public void showListOfCars(DataTable dt)
        {
            int row_tot = dt.Rows.Count;

            int row_number = 1;

            Panel Panel1 = new Panel();

            Panel1.Controls.Add(new LiteralControl("<table>"));

            foreach (DataRow row in dt.Rows)
            {

                if (row_tot >= row_number)
                {
                    
                    Panel1.Controls.Add(new LiteralControl("<tr>"));
                    Panel1.Controls.Add(new LiteralControl("<td width='200px'>"));

                    Image img = new Image();
                    if (!row.IsNull("ImageURL"))
                    {
                        img.ImageUrl = "../images/" + dt.Rows[row_number - 1].Field<string>(0);
                    }
                    img.ID = "imgImage" + row_number.ToString();

                    Panel1.Controls.Add(img);
                    Panel1.Controls.Add(new LiteralControl("<br />"));

                    Panel1.Controls.Add(new LiteralControl("</td>"));
                    Panel1.Controls.Add(new LiteralControl("<td>"));

                    Label myLabel = new Label();

                    if (!row.IsNull("FullName"))
                    {
                        myLabel.Text += "<p style='font-size:18px;color:darkgrey;'><strong>" + dt.Rows[row_number - 1].Field<string>(1) + "</strong></p>";
                    }
                    if (!row.IsNull("Colour"))
                    {
                        myLabel.Text += "Färg: " + dt.Rows[row_number - 1].Field<string>(2) + " ";
                    }
                    if (!row.IsNull("ModelYear"))
                    {
                        myLabel.Text += "Årsmodell: " + dt.Rows[row_number - 1].Field<int>(3).ToString() + "<br>";
                    }
                    if (!row.IsNull("Fuel"))
                    {
                        myLabel.Text += "Drivmedel: " + dt.Rows[row_number - 1].Field<string>(5) + " ";
                    }
                    if (!row.IsNull("Mileage"))
                    {
                        myLabel.Text += "Mätarställning: " + dt.Rows[row_number - 1].Field<string>(6) + "<br>";
                    }
                    if (!row.IsNull("Region"))
                    {
                        myLabel.Text += "Ort: " + dt.Rows[row_number - 1].Field<string>(7) + "<br>";
                    }
                    if (!row.IsNull("Transmission"))
                    {
                        myLabel.Text += "Växellåda: " + dt.Rows[row_number - 1].Field<string>(8) + " ";
                    }
                    if (!row.IsNull("Horsepower"))
                    {
                        myLabel.Text += "Hästkrafter: " + dt.Rows[row_number - 1].Field<string>(9) + "<br>";
                    }
                    if (!row.IsNull("Shaft"))
                    {
                        myLabel.Text += "Drivaxlar: " + dt.Rows[row_number - 1].Field<string>(10) + " ";
                    }
                    if (!row.IsNull("Body"))
                    {
                        myLabel.Text += "Kaross: " + dt.Rows[row_number - 1].Field<string>(11) + "<br>";
                    }
                    myLabel.ID = "lblLabel" + row_number.ToString();

                    Panel1.Controls.Add(myLabel);

                    Panel1.Controls.Add(new LiteralControl("<br />"));

                    row_number++;

                    Panel1.Controls.Add(new LiteralControl("</td>"));
                    Panel1.Controls.Add(new LiteralControl("</tr>"));
                }
                else
                {
                    Panel1.Controls.Add(new LiteralControl("<tr>"));
                    Panel1.Controls.Add(new LiteralControl("<td>"));
                    Panel1.Controls.Add(new LiteralControl("</td>"));
                    Panel1.Controls.Add(new LiteralControl("</tr>"));
                }

            }
            Panel1.Controls.Add(new LiteralControl("</table>"));
        }

    }
}