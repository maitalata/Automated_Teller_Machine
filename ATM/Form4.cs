using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=atm.db3;Version=3");
        SQLiteDataReader searchReader;

        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            m_dbConnection.Open();

            String sql = "SELECT * FROM customers ORDER BY id DESC";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            searchReader = command.ExecuteReader();
            searchReader.Read();
            textBox1.Text = searchReader["firstName"] + " " + searchReader["lastName"];
            textBox2.Text = searchReader["accountNumber"].ToString();
            textBox3.Text = searchReader["password"].ToString();
            textBox4.Text = searchReader["initialDeposit"].ToString();
        }
    }
}
