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
        private void Form1_Load(object sender,EventArgs e)
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

            TrainInfo.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Isvalid())

            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TrainTB VALUES (@TrainName, @StartingStation,@StopingStation,@currentStation)", con );
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TrainName", txttraName.Text);
                cmd.Parameters.AddWithValue("@StartingStation", txtstart.Text);
                cmd.Parameters.AddWithValue("@StopingStation", txtlast .Text);
                cmd.Parameters.AddWithValue("@currentStation", txtcurren.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetTrainInfo();
            }
        }
        private bool Isvalid()
        {
            if (txttraId.Text ==string.Empty)
            {
                MessageBox.Show("Name is required", "failled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttraName.Clear();
            txtstart.Clear();
            
        }
    }
}
