using Conntact_App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conntact_App
{
    public partial class econtact : Form
    {
        public econtact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();
        
        
        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            c.FirstName = FirstName.Text;
            c.LastName = LastName.Text;
            c.ContactNO = ContactNO.Text;
            c.Address = Address.Text;
            c.Gender = Gender.Text;
            bool success = c.insert(c);
            if (success == true)
            {
                MessageBox.Show("New Contact Successfuly Added");
                clear();

            }
            else
            {
                MessageBox.Show("Failed to Added New Contact");
            }
            //load data to data view
            DataTable dt = c.Select();
            contactList.DataSource = dt;
        }

        private void econtact_Load(object sender, EventArgs e)
        {
            //load data to data view
            DataTable dt = c.Select();
            contactList.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void clear()
        {
            FirstName.Text = "";
            LastName.Text = "";
            ContactNO.Text = "";
            Address.Text = "";
            Gender.Text = "";
            ContactID.Text = "";

        }

        private void contactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            ContactID.Text = contactList.Rows[rowindex].Cells[0].Value.ToString();
            FirstName.Text = contactList.Rows[rowindex].Cells[1].Value.ToString();
            LastName.Text = contactList.Rows[rowindex].Cells[2].Value.ToString();
            ContactNO.Text = contactList.Rows[rowindex].Cells[3].Value.ToString();
            Address.Text = contactList.Rows[rowindex].Cells[4].Value.ToString();
            Gender.Text = contactList.Rows[rowindex].Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(ContactID.Text);
            c.FirstName = FirstName.Text;
            c.LastName = LastName.Text;
            c.ContactNO = ContactNO.Text;
            c.Address = Address.Text;
            c.Gender = Gender.Text;
            bool success = c.Update(c);
            if (success == true)
            {
                MessageBox.Show("New Contact Successfuly Updated");
                //load data to data view
                DataTable dt = c.Select();
                contactList.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Failed to update Contact");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(ContactID.Text);
            bool success = c.Delete(c);
            if(success == true)
            {
                MessageBox.Show("contact has been deleted");
                DataTable dt = c.Select();
                contactList.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("contact failed to delete");
            }
        }
        public string conString = "Data Source=DESKTOP-B8TG6GO\\SQLEXPRESS;Initial Catalog=Econtact;Integrated Security=True";

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox6.Text;
            SqlConnection conn = new SqlConnection(conString);
            SqlDataAdapter ads = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE '%" + keyword + "%' OR LastName LIKE '%" + keyword + "' OR Address LIKE'%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            ads.Fill(dt);
            contactList.DataSource = dt;

        }
    }
}
