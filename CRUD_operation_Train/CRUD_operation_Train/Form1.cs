using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CRUD_operation_Train
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LNO9I49\SQLEXPRESS;Initial Catalog=TrainInfo;Integrated Security=True");
        public int TrainID; 
        private void Form1_Load_1(object sender, EventArgs e)
        {
            GetTrainInfo();
        }


        private void GetTrainInfo()
        {

            SqlCommand cmd = new SqlCommand("select * from TrainTB", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);

            con.Close();

            TrainInfogv.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Isvalid())

            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TrainTB VALUES (@TrainName, @StartingStation,@StopingStation,@currentStation", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TrainName", txttraName.Text);
                cmd.Parameters.AddWithValue("@StartingStation", txtstart.Text);
                cmd.Parameters.AddWithValue("@StopingStation", txtlast.Text);
                cmd.Parameters.AddWithValue("@currentStation", txtcurren.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetTrainInfo();
                ResetForm();
            }
        }
        private bool Isvalid()
        {
            if (txttraId.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "failled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm();

        }

        private void ResetForm()
        {
            txttraName.Clear();
            txtstart.Clear();
            txtlast.clear();
            txtcurren.clear();
            txttraName.Focus();
        }

        private void TrainInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TrainID = Convert.ToInt32(TrainInfogv.Rows[0].Cells[0].Value); 
            txttraName.Text = TrainInfogv.SelectedRows[0].Cells[1].Value.ToString();
            txtstart.Text = TrainInfogv.SelectedRows[0].Cells[2].Value.ToString();
            txtlast.Text = TrainInfogv.SelectedRows[0].Cells[3].Value.ToString();
            txtcurren.Text = TrainInfogv.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TrainID>0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE TrainTB SET TrainName = @TrainName,StartingStation = @StartingStation, StopingStation = @StopingStation,StopingStation = @currentStation WHERE TrainID =@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TrainName", txttraName.Text);
                cmd.Parameters.AddWithValue("@StartingStation", txtstart.Text);
                cmd.Parameters.AddWithValue("@StopingStation", txtlast.Text);
                cmd.Parameters.AddWithValue("@currentStation", txtcurren.Text);
                cmd.Parameters.AddWithValue("@TrainID", this.TrainID);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetTrainInfo();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Please  select a infomation", "select?");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(TrainID>0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TrainTB  WHERE TrainID =@ID", con);
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("@TrainID", this.TrainID);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Please  select a infomation", "Delete?");
            }
        }

        private void TrainInfogv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }












