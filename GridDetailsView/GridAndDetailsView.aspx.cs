using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridDetailsView
{
    public partial class GridAndDetailsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = System.Drawing.Color.Black;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = "A database error has occurred. " +
                    "Message: " + e.Exception.Message;
                e.ExceptionHandled = true;
                e.KeepInInsertMode = true;
                lblError.Text = DataValidation(e);
            }
            else if (e.AffectedRows == 0)
                lblError.Text = "Another user may have updated that product. " +
                    "Please try again. ";
            else
            {
                lblError.Text = "New record was successfully added. ";
                GridView1.DataBind();
            }
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = "A database error has occurred. " +
                    "Message: " + e.Exception.Message;
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
                lblError.Text = DataValidation(e);                

                //decimal testfield = 0m;
                //if (!(Decimal.TryParse(e.NewValues["UnitPrice"].ToString(), out testfield)))
                //    lblError.Text = "Unit Price not numeric ";

            }
            else if (e.AffectedRows == 0)
                lblError.Text = "Another user may have updated that product. " +
                    "Please try again. ";
            else
            {
                lblError.Text = "Record was successfully updated. ";
                GridView1.DataBind();
            }
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        // this code does not execute
        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = "A database error has occurred. " +
                    "Message: " + e.Exception.Message;
                e.ExceptionHandled = true;                
            }
            else if (e.AffectedRows == 0)
                lblError.Text = "Another user may have updated that product. " +
                    "Please try again. ";
            else
            {
                lblError.Text = "Record was successfully deleted. ";
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblError.Text = "A database error has occurred. " +
                    "Message: " + e.Exception.Message;
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == 0)
                lblError.Text = "Another user may have updated that product. " +
                    "Please try again. ";
            else
            {
                lblError.Text = "Record was successfully deleted. ";
                GridView1.DataBind();
            }
        }

        protected String DataValidation(DetailsViewInsertedEventArgs e)
        {
            //if (e.Values["UnitPrice"].ToString() == "4")
            decimal testfield = 0m;
            if (!(Decimal.TryParse(e.Values["UnitPrice"].ToString(), out testfield)))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Unit Price must be numeric ";
            }

            if (!(Decimal.TryParse(e.Values["OnHand"].ToString(), out testfield)))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Inventory On Hand must be numeric ";
            }

            int number;
            if (!(Int32.TryParse(e.Values["OnHand"].ToString(), out number)))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "On Hand field must be an Integer ";
            }

            return lblError.Text;
        }

        protected String DataValidation(DetailsViewUpdatedEventArgs e)
        {
            decimal testfield = 0m;
            if (!(Decimal.TryParse(e.NewValues["UnitPrice"].ToString(), out testfield)))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Unit Price must be numeric ";
            }

            if (!(Decimal.TryParse(e.NewValues["OnHand"].ToString(), out testfield)))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Inventory On Hand must be numeric ";
            }

            int number;
            if (!(Int32.TryParse(e.NewValues["OnHand"].ToString(), out number)))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "On Hand field must be an Integer ";
            }

            return lblError.Text;
        }
    }
}