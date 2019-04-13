using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace ViewDateForm
{
    public partial class Shamsi : Form
    {
        List<Button> listOfButtons = new List<Button>(31);
        //private readonly object myDic;
        public static Dictionary<int, string> dic = new Dictionary<int, string>()

            {
                { 1 , "I don’t want to earn my living; I want to live." },
                { 2 , "This is your life, and it’s ending one minute at a time." },
                { 3 , " Youth is counted sweetest by those who are no longer young." },
                { 4 , " Everything happens for a reason." },
                { 5 , " Be the change you wish to see in the world." },
                { 6 , " Whatever you are, be a good one." },
                { 7 , " So it goes." },
                { 8 , " The trouble is you think you have time." },
                { 9 , " Life is a one time offer, use it well." },
                { 10 , " Life shrinks or expands in proportion to one’s courage." },
                { 11 , " Live for yourself." },
                { 12 , " Love the life you live, and live the life you love." },
                { 13 , " What screws us up the most in life is the picture in our head of how it is supposed to be." },
                { 14 , " Life is short. Live passionately." },
                { 15 , " It has been my philosophy of life that difficulties vanish when faced boldly." },
                { 16 , " A man is not old until his regrets take the place of his dreams." }
                
        };

        public Shamsi()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            int numofdays = 0;
            Button tmpButton;


            if (comboBox2.SelectedIndex < 6)
                numofdays = 31;
            else if (comboBox2.SelectedIndex < 10)
                numofdays = 30;
            else if (comboBox2.SelectedIndex > 10)
                numofdays = 29;

            if (flowLayoutPanel1.Visible)
            {
                foreach (var b in listOfButtons)
                    b.Dispose();
            }

            for (int i = 1; i <= numofdays; i++)
            {
                tmpButton = new Button();
                tmpButton.Parent = flowLayoutPanel1;
                tmpButton.Text = i.ToString();
                tmpButton.Click += new System.EventHandler(this.Numbers_Click);
                listOfButtons.Add(tmpButton);
                tmpButton = null;
            }

            flowLayoutPanel1.Visible = true;


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private static int Random(int c)
        //{
        //    throw new NotImplementedException();

        //}

        private void Numbers_Click(object sender, EventArgs e)
        {

            int Myday = Convert.ToInt32(((Button)sender).Text);
            int Mymonth = comboBox2.SelectedIndex + 1 ;
            int Myyear = Convert.ToInt32(comboBox1.SelectedItem);
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime date1 = new DateTime(Myyear, Mymonth, Myday, pc);
            textBox2.Text = date1.Year.ToString("0000/") + date1.Month.ToString("00/") + date1.Day.ToString("00");
            Random rnd = new Random();
            int c = rnd.Next(1,16);
            textBox1.Text = dic[c];

        }

        private void Shamsi_Load_1(object sender, EventArgs e)
        {
            ComboBox comboBox1 = (ComboBox)this.Controls.Find("comboBox1", true)[0];
            int yeardate;
            yeardate = DateTime.Now.Year - 621;
            for (int x = 0; x <= 10; x++)
            {
                comboBox1.Items.Add(yeardate - x);
            }
            comboBox1.SelectedIndex = 0;

        }
    }
    }

