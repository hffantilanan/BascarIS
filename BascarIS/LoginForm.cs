using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BascarIS
{
    public partial class LoginForm : Form
    {
        //declare new variable named dataTable as New Datatable
        DataTable dataTable = new DataTable();
        //this line of code used to connect to the server and locate the database 

        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=toor;database=dblinventory;");



public LoginForm()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
           // dataTable = new DataTable();
            //this query will give us the result based on user input for Username and Password
            string sql = "Select * from tblusers where username='" + txtusername.Text + "' AND UserPassword='" +
                         txtpass.Text + "'";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql,conn);
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("OK!!!");
                    Hide();

            MDIMain mdiMain = new MDIMain();
                mdiMain.Show();

            }
            else
            {
                MessageBox.Show("access denied!!");
            }
        }
    }
}
