using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherApp;
using Newtonsoft;
using Newtonsoft.Json.Linq;


namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private Query Q;
        private CheckBox lastChecked = null;
        public Form1()
        {
            InitializeComponent();
             Q = new Query("644657d0b5c14373bef2b90e92d34c12");
            this.checkBox1.Checked = true;
            lastChecked = checkBox1;
            label1.Text = "City:\nTemp:\nDesc:";
        }

      


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string City = textBox1.Text;
            string Units;
            if (City.Length>0)
                
            {
               if( lastChecked.Text=="F")
                {
                    Units = "imperial";
                }
               else if(lastChecked.Text=="C")
                {
                    Units = "metric";
                }
               else 
                {
                    Units = "standard";
                }
               string response= Q.GetForecast(City,1,Units);
                JObject forecast = JObject.Parse(response);
                label1.Text = "City:" + forecast.SelectToken("city.name").ToString()+"\nTemp:"+ forecast.SelectToken("list[0].main.temp").ToString()+"\nDesc:" + forecast.SelectToken("list[0].weather[0].description").ToString();

                

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
