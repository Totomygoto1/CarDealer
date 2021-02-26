using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CarDealer
{
    public partial class CarViewAdmin : System.Web.UI.Page
    {
        private String strConnString = ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Write as Class ..... 
            // Add Parameter for ModelYear & ImageURL .....

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {

            string strQuery = "select CarId,FullName,Colour" +

                               " from Cars2";

            SqlConnection sqlConnection1 = new SqlConnection("Data Source=DESKTOP-QSKN5L9\\SQLEXPRESS;Initial Catalog=CarDealer;Integrated Security=True");
            sqlConnection1.Open();

            SqlCommand cmd = new SqlCommand(strQuery, sqlConnection1);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();

            sqlConnection1.Close();
        }

        protected void AddNewCar(object sender, EventArgs e)
        {
            // Try and parse again .... says wrong format ....

            string FullName = ((TextBox)GridView1.FooterRow.FindControl("txtFullName")).Text;

            string Colour = ((TextBox)GridView1.FooterRow.FindControl("txtColour")).Text;

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;

            /*
            cmd.CommandText = " if not exists(select * from Cars where FullName = '" + FullName + "' and CarId = '" + CarID + "') " +
            " insert into Cars(FullName,Colour) values('" + FullName + "','" + Colour + "') " +
            "select CarId,FullName,Colour from cars";
            */

            cmd.CommandText = "insert into Cars2(FullName, Colour) " +

            "values(@FullName, @Colour);";

            cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = FullName;

            cmd.Parameters.Add("@Colour", SqlDbType.VarChar).Value = Colour;

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();

            BindData();

        }

        protected void EditCar(object sender, GridViewEditEventArgs e)

        {

            GridView1.EditIndex = e.NewEditIndex;

            BindData();

        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)

        {

            GridView1.EditIndex = -1;

            BindData();

        }

        protected void UpdateCar(object sender, GridViewUpdateEventArgs e)
        {

            string CarId = ((Label)GridView1.Rows[e.RowIndex]

                                .FindControl("lblCarId")).Text;

            string FullName = ((TextBox)GridView1.Rows[e.RowIndex]

                                .FindControl("txtFullName")).Text;

            string Colour = ((TextBox)GridView1.Rows[e.RowIndex]

                                .FindControl("txtColour")).Text;

            int CarID = Int32.Parse(CarId);

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update Cars2 set FullName=@FullName," +

            "Colour=@Colour where CarId=@CarId;" +

            "select CarId,FullName,Colour from Cars2";

            cmd.Parameters.Add("@CarId", SqlDbType.Int).Value = CarID;

            cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = FullName;

            cmd.Parameters.Add("@Colour", SqlDbType.VarChar).Value = Colour;

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            GridView1.EditIndex = -1;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();

            con.Close();

        }

        protected void DeleteCar(object sender, EventArgs e)

        {

            LinkButton lnkRemove = (LinkButton)sender;

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "delete from Cars2 where " +

            "CarId=@CarId;" +

            "select CarId,FullName,Colour from Cars2";

            cmd.Parameters.Add("@CarId", SqlDbType.Int).Value

                = lnkRemove.CommandArgument;

            // GridView1.DataSource = GetData(cmd);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;

            GridView1.DataBind();

            con.Close();

        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {

            BindData();

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();

        }
    }
}