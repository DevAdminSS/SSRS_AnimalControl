using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AnimalControl
{
    public partial class DALIncidents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // LoadData();
                ClearRecs();
                lblSuccess.Visible = false;

                string PrjID = Request.QueryString["ProjID"];
                if (PrjID != null)
                {
                    int pjID =  int.Parse(PrjID);
                    DALTableAdapters.SelectIncidentsTableAdapter selInc = new DALTableAdapters.SelectIncidentsTableAdapter();
                    DAL.SelectIncidentsDataTable selTable = selInc.GetData(pjID);
                    if (selTable.Count > 0)
                    {
                        FillInitialData(selTable.Rows[0]);
                    }
                }
            }


        }

        protected void InsertRec(object sender, EventArgs e)
        {
            string CITWWW = txtCIT.Text;
            if (CITWWW != "")
            {
                int CIT = int.Parse(CITWWW);
                string Name = txtAnimal.Text;
                string Breed = txtBreed.Text;
                string OwnerAddr = txtAddr.Text;
                string ownerNameFirst = txtOwnerFirst.Text;
                string ownerNameLast = txtOwnerLast.Text;
                DateTime? DOB = null;
                DateTime? DateOffense = null;
                if (txtDOB.Text != "")
                    DOB = DateTime.Parse(txtDOB.Text.ToString());
                if (txtDate.Text != "")
                    DateOffense = DateTime.Parse(txtDate.Text.ToString());
                string AreaPick = txtAreaPickedUp.Text;
                string Officer = txtOfficer.Text;
                string Disposition = txtDisposition.Text;
                string Comments = txtComments.Text;

                DALTableAdapters.SelectIncidentsTableAdapter selAdpt = new DALTableAdapters.SelectIncidentsTableAdapter();
                int cnt = selAdpt.Insert(Name, Breed, OwnerAddr,ownerNameLast, ownerNameFirst, DOB, AreaPick, Disposition, CIT, DateOffense, Officer, Comments);
                if (cnt == 1)
                {
                    lblSuccess.Text = "Record Inserted Successfully!";
                    lblSuccess.Visible = true;
                    ClearRecs();
                }
            }
            else
            {
                lblSuccess.Text = "Please Provide a CITWWW Number";
                lblSuccess.Visible = true;
            }
        }
        private void ClearRecs()
        {
            txtID.Text = "";
            txtAnimal.Text = "";
            txtBreed.Text = "";
            txtAddr.Text = "";
            txtOwnerFirst.Text = "";
            txtOwnerLast.Text = "";
            txtDOB.Text = "";
            txtAreaPickedUp.Text = "";
            txtDisposition.Text = "";
            txtCIT.Text = "";
            txtDate.Text = "";
            txtOfficer.Text = "";
            txtComments.Text = "";

        }
        private void FillInitialData(DataRow rw)
        {
            txtID.Text = rw["ID"].ToString();
            txtAnimal.Text = rw["Name"].ToString();
            txtBreed.Text = rw["Breed"].ToString();
            txtAddr.Text = rw["OwnerAddr"].ToString();
            txtOwnerFirst.Text = rw["FirstName"].ToString();
            txtOwnerLast.Text = rw["LastName"].ToString();
            txtDOB.Text = rw["DOB"].ToString();
            txtAreaPickedUp.Text = rw["AreaPickedUp"].ToString();
            txtDisposition.Text = rw["Disposition"].ToString();
            txtCIT.Text = rw["CITWWW"].ToString();
            txtDate.Text = rw["DateOffense"].ToString();
            txtOfficer.Text = rw["Officer"].ToString();
            txtComments.Text = rw["Comments"].ToString();
            btnUpdate.Enabled = true;
            btnInsert.Enabled = false;
        }

        protected void UpdateRec(object sender, EventArgs e)
        {
            string CITWWW = txtCIT.Text;
            if (CITWWW != "")
            {
                int id = int.Parse(txtID.Text);
                int CIT = int.Parse(CITWWW);
                string Name = txtAnimal.Text;
                string Breed = txtBreed.Text;
                string OwnerAddr = txtAddr.Text;
                string ownerNameFirst = txtOwnerFirst.Text;
                string ownerNameLast = txtOwnerLast.Text;
                DateTime? DOB = null;
                DateTime? DateOffense = null;
                if (txtDOB.Text != "")
                    DOB = DateTime.Parse(txtDOB.Text.ToString());
                if (txtDate.Text != "")
                    DateOffense = DateTime.Parse(txtDate.Text.ToString());
                string AreaPick = txtAreaPickedUp.Text;
                string Officer = txtOfficer.Text;
                string Disposition = txtDisposition.Text;
                string Comments = txtComments.Text;



                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AnimalControlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateDAL";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;
                cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = Name;
                cmd.Parameters.Add("@Breed", SqlDbType.NVarChar, 150).Value = Breed;
                cmd.Parameters.Add("@OwnerAddr", SqlDbType.NVarChar, 150).Value = OwnerAddr;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = ownerNameLast;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = ownerNameFirst;
                cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = DOB;
                cmd.Parameters.Add("@AreaPickedUp", SqlDbType.NVarChar, 150).Value = AreaPick;
                cmd.Parameters.Add("@Disposition", SqlDbType.NVarChar, 100).Value = Disposition;
                cmd.Parameters.Add("@CITWWW", SqlDbType.Int).Value = CIT;
                cmd.Parameters.Add("@DateOffense", SqlDbType.DateTime).Value = DateOffense;
                cmd.Parameters.Add("@Officer", SqlDbType.NVarChar, 150).Value = Officer;
                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar, 300).Value = Comments;
               

                int rowsAffected = 0;
                try
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblSuccess.Text = "Record Sucessfully Updated!";
                        lblSuccess.Visible = true;
                        ClearRecs();
                        btnUpdate.Enabled = false;
                        btnInsert.Enabled = true;
                    }
                    conn.Close();
                }
                catch (SqlException sqlex)
                {
                    string st = sqlex.Message;
                }
            }
        }

        protected void Clear(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnInsert.Enabled = true;
            ClearRecs();
        }
    }
}