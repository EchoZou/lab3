using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements required for EF DB access
using lab3.Models;
using System.Web.ModelBinding;

namespace lab3
{
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            //populate the form with existing data from the database
            int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            //connect to the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a student object instance with the StudentID from the URL parameter
                Department updatedDepartment = (from Department in db.Departments
                                             where Department.DepartmentID == DepartmentID
                                             select Department).FirstOrDefault();

                //map the student properties to the form controls
                if (updatedDepartment != null)
                {
                    DepartmentNameTextBox.Text = updatedDepartment.Name;
                    BudgetTextBox.Text = updatedDepartment.Budget.ToString("c");
                }
            }
        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students page
            Response.Redirect("~/Departments.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                // use the Student model to create a new student object and
                // save a new record
                Department newDepartment = new Department();

                int DepartmentID = 0;

                if (Request.QueryString.Count > 0) // our URL has studentID in it
                {
                    //get the id from the URL
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    //get the current student from EF DB
                    newDepartment = (from Department in db.Departments
                                     where Department.DepartmentID == DepartmentID
                                     select Department).FirstOrDefault();
                }

                // add form data to the new student record
                newDepartment.Name = DepartmentNameTextBox.Text;
                newDepartment.Budget = Convert.ToDecimal(BudgetTextBox.Text);

                // use LINQ to ADO.NET to add / insert new student into the database
                if (DepartmentID == 0)
                {
                    db.Departments.Add(newDepartment);
                }


                // save our changes
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}
        