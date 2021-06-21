﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace BillingSystem
{
    public partial class customer_register : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQN7RPE;Initial Catalog=Billing_system;Integrated Security=True;Pooling=False");
        

        string pwd = Class1.GetRandomPassword(20);
        string wanted_path;

        public customer_register()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string img_path;
                File.Copy(openFileDialog1.FileName, wanted_path + "\\customer_image\\" + pwd + ".jpg");
                img_path = "customer_image\\" + pwd + ".jpg";

                con.Open();
              SqlCommand cmd = con.CreateCommand();
              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "insert into customer values('" + name.Text + "','" + address.Text + "','" + contact.Text + "','" + email.Text + "','" + dateTimePicker1.Value + "','" + member.Text + "','" + img_path.ToString() + "' )";
               

              cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted successfully!!");
           }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
}
    

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            { 
                wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
               DialogResult result = openFileDialog1.ShowDialog();
               openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files(*.png)|*.png|JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif";
               if (result == DialogResult.OK)  // Test result
               {
                 customer_image.ImageLocation = openFileDialog1.FileName;
                 customer_image.SizeMode = PictureBoxSizeMode.StretchImage;
               }
              // pictureBox1.ImageLocation = @"..\..\student_images\" + pwd +".jpg";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
           

    }
}
    

