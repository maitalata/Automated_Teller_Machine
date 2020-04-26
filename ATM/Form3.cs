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
    public partial class Form3 : Form
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=atm.db3;Version=3");

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            m_dbConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string sex = textBox3.Text;
            string civilStatus = textBox4.Text;
            string address = textBox5.Text;
            Random rnd = new Random();
            int n = rnd.Next(1000, 9999);
            int acc = rnd.Next(10000, 99999);
            int acc2 = rnd.Next(10000, 99999);
            string password = n.ToString();
            string accountNumber = acc.ToString()+acc2.ToString();
            string initialDeposit = textBox6.Text;

            string sql = @"INSERT INTO customers(firstName, lastName, sex, civilStatus, address, accountNumber, password, initialDeposit) 
                                  VALUES('" + firstName + "','" + lastName + "','" + sex + @"',
                               '" + civilStatus + "','" + address + "','" + accountNumber + "','" + password + "','" + initialDeposit + "')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            this.Close();

            Form4 frm4 = new Form4();
            frm4.ShowDialog();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
