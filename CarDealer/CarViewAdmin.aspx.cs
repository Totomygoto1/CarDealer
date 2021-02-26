using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CarDealer.HelperClass;

namespace CarDealer
{
    public partial class CarViewAdmin : System.Web.UI.Page
    {
        private String strConnString = ConfigurationManager.ConnectionStrings["CarDealerConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            Admin ad1 = new Admin();
            DataTable dt = ad1.ViewData();

            GridView1.DataSource = dt;

            GridView1.DataBind();

        }

        protected void AddNewCar(object sender, EventArgs e)
        {
            string FullName = ((TextBox)GridView1.FooterRow.FindControl("txtFullName")).Text;

            string Colour = ((TextBox)GridView1.FooterRow.FindControl("txtColour")).Text;

            string ImageURL = ((TextBox)GridView1.FooterRow.FindControl("txtImageURL")).Text;

            string ModelYear = ((TextBox)GridView1.FooterRow.FindControl("txtModelYear")).Text;

            Admin ad2 = new Admin();
            ad2.AddNewCar(FullName, Colour, ImageURL, ModelYear);

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

            string ImageURL = ((TextBox)GridView1.Rows[e.RowIndex]

                                .FindControl("txtImageURL")).Text;

            string ModelYear = ((TextBox)GridView1.Rows[e.RowIndex]

                                .FindControl("txtModelYear")).Text;


            int CarID = Int32.Parse(CarId);

            Admin ad3 = new Admin();
            DataTable dt = ad3.UpdateCar(CarId, FullName, Colour, ImageURL, ModelYear);

            GridView1.EditIndex = -1;

            GridView1.DataSource = dt;

            GridView1.DataBind();

        }

        protected void DeleteCar(object sender, EventArgs e)
        {

            LinkButton lnkRemove = (LinkButton)sender;
            string CarId = lnkRemove.CommandArgument;

            Admin ad4 = new Admin();
            DataTable dt = ad4.DeleteCar(CarId);
            
            GridView1.DataSource = dt;

            GridView1.DataBind();

        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {

            BindData();

            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();

        }
    }
}