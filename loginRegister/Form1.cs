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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
           
        }
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=users;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
        
        private void btnkayitol_Click(object sender, EventArgs e)
        {
            if (txtisim.Text == "" && txtsifre.Text == "" && txtsifretekrar.Text == "")
            {
                MessageBox.Show("Lütfen Kutucukları Boş Bırakmayınız !!! ", "Tekrar Deneyiniz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtsifre.Text == txtsifretekrar.Text)
            {


                conn.Open();
                String register = "INSERT INTO users_table VALUES('" + txtisim.Text + "','" + txtsifre.Text + "')";
                cmd = new SqlCommand(register, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                txtisim.Text = "";
                txtsifre.Text = "";
                txtsifretekrar.Text = "";
                MessageBox.Show("Hesabınız Başarıyla Oluşturuldu !!!", "Kayır Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
                MessageBox.Show("Şifreler birbirleriyle eşleşmiyor !!!","Tekrar Deneyiniz",MessageBoxButtons.OK,MessageBoxIcon.Error);
            txtsifre.Text = "";
            txtsifretekrar.Text = "";
            txtsifre.Focus();
        }

        private void txtsifretekrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtisim.Text = "";
            txtsifre.Text = "";
            txtsifretekrar.Text = "";
        }

        private void checkboxsifregoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxsifregoster.Checked)
            {
                txtsifre.PasswordChar = '\0';
                txtsifretekrar.PasswordChar = '\0';

            }
            else
            {
                txtsifre.PasswordChar = '*';
                txtsifretekrar.PasswordChar = '*';

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
