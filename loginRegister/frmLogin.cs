using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace loginRegister
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=users;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void checkboxsifregoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxsifregoster.Checked)
            {
                txtsifre.PasswordChar = '\0';
                

            }
            else
            {
                txtsifre.PasswordChar = '*';
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtisim.Text = "";
            txtsifre.Text = "";
            txtisim.Focus();   
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnkayitol_Click(object sender, EventArgs e)
        {
            conn.Open();
            String login ="SELECT * FROM users_table WHERE name='"+txtisim.Text+"'AND password='"+txtsifre.Text+"' ";
            cmd=new SqlCommand(login,conn);
            SqlDataReader da=cmd.ExecuteReader();
            if (da.Read()==true) {
                new mainDashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Bilgileri Yanlış !!!", "Lütfen Tekrar Deneyiniz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtisim.Text = "";
                txtsifre.Text = "";
                txtisim.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
