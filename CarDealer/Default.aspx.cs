using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CarDealer.HelperClass;

namespace CarDealer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            lblError.Text = "";

            // Check Modelyear textbox for wrong input - accept only digits, if n == 0 no wrong input, display Cars.
            int n = 0;

            try
            {
                if (txtTextBox3.Text.Length > 0)
                {
                    int m = Int32.Parse(txtTextBox3.Text);
                }

            }
            catch
            {
                lblError.Text = "Please write only digits for Modelyear.";
                n = 1;
            }


            if (n == 0)
            {
                // Call for function to Build the Query string based on textbox Input

                Procedures prod = new Procedures();
                string make = txtTextBox1.Text;
                string colour = txtTextBox2.Text;
                string modelyear = txtTextBox3.Text;

                DataTable dt = prod.searchCars(make,colour,modelyear);
                
                int row_tot = dt.Rows.Count;

                // After Search, List All ...

                int row_number = 1;

                Panel1.Controls.Add(new LiteralControl("<table>"));

                foreach (DataRow row in dt.Rows)
                {

                    if (row_tot >= row_number)
                    {
                        // Display the Cars ... Check for Null ...
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
}