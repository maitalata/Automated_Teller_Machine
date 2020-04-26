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
    public partial class Form2 : Form
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=atm.db3;Version=3");
        SQLiteDataReader searchReader;

        string context;
        string account = "";
        string password = "";
        string withdrawAmount = "";
        string depositAmount = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            m_dbConnection.Open();

            label10.Hide();
            textBox1.Hide();

            button1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM customers WHERE accountNumber='" + account + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            searchReader = command.ExecuteReader();

            searchReader.Read();

            MessageBox.Show("Your Account Balance is "+searchReader["initialDeposit"]);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            textBox1.Hide();

            label9.Text = "Select Transaction";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ATM System For Access Bank\nKano State Polytechnic Final Year Project");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            label2.Text = "CARD INSERTED";
            label10.Show();
            textBox1.Show();

            context = "account insert";
            label9.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            label2.Text = "INSERT ATM CARD HERE !!";
            label10.Hide();
            textBox1.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(context == "account insert"){
                account = textBox1.Text;

                String sql = "SELECT * FROM customers WHERE accountNumber='"+account+"'";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                searchReader = command.ExecuteReader();

                if (searchReader.HasRows)
                {
                    label10.Text = "Enter Your Password";
                    textBox1.Text = "";
                    context = "password";
                    label9.Text = "";
                }
                else
                {
                    label9.Text = "Invalid Account Number";
                    textBox1.Text = "";
                }

            }

            if (context == "password")
            {
                password = textBox1.Text;

                String sql = "SELECT * FROM customers WHERE accountNumber='" + account + "' AND password='"+password+"'";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                searchReader = command.ExecuteReader();

                if (searchReader.HasRows)
                {
                    button1.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;

                    label9.ForeColor = Color.Green;
                    label9.Text = "Logged In Successfully";
                    context = "logged";
                }
                else
                {
                    if(textBox1.Text != ""){
                        label9.Text = "Incorrect Password";
                        textBox1.Text = "";
                    }
                    
                }

            }

            if (context == "deposit")
            {
                depositAmount = textBox1.Text;

                string sql = @"UPDATE customers SET initialDeposit=initialDeposit+"+depositAmount+" WHERE accountNumber='"+account+"' AND password='"+password+"'";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                label9.Text = "Amount Deposited Successfully";
                textBox1.Text = "";
            }

            if (context == "withdraw")
            {

                withdrawAmount = textBox1.Text;

                String sql = "SELECT * FROM customers WHERE accountNumber='" + account + "'";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                searchReader = command.ExecuteReader();

                searchReader.Read();

                if (Double.Parse(withdrawAmount) > Double.Parse(searchReader["initialDeposit"].ToString()))
                {
                    MessageBox.Show("Insufficient Balance");
                }
                else
                {
                    sql = @"UPDATE customers SET initialDeposit=initialDeposit-" + withdrawAmount + " WHERE accountNumber='" + account + "' AND password='" + password + "'";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    label9.Text = "Transaction Successfull";
                    label7.Text = withdrawAmount;
                }

                

               
            }

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = "Enter Deposit Ammount";
            textBox1.Text = "";

            context = "deposit";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label10.Text = "Enter Amount to Withdraw";
            textBox1.Text = "";

            context = "withdraw";
        }
    }
}
