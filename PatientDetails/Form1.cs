using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDetails
{
    public partial class Form1 : Form
    {
        PatientEntities db;
        public Form1()
        {
            InitializeComponent();
            db = new PatientEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newPt = new Patient_Details
            {
                Id = Convert.ToInt32(textBox1.Text),
                Name = textBox2.Text,
                Gender = radioButton1.Checked ? "Male" : "Female",
                Address = textBox3.Text,
                PostalCode = textBox4.Text,
                PhoneNumber = textBox5.Text
            };
            db.Patient_Details.Add(newPt);
            db.SaveChanges();
            MessageBox.Show("Patient added: " + textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pts = db.Patient_Details.ToList();
            int index = 0;
            foreach (var pt in pts)
            {
                if (pt.Id == Convert.ToInt32(textBox1.Text))
                {

                    pt.Name = textBox2.Text;
                    pt.Gender = radioButton1.Checked ? "Male" : "Female";
                    pt.Address = textBox3.Text;
                    pt.PostalCode = textBox4.Text;
                    pt.PhoneNumber = textBox5.Text;
                    db.Patient_Details.ToList()[index] = pt;
                    db.SaveChanges();
                    MessageBox.Show("Patient Updated: " + pt.Id);
                    break;
                }
                index++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    int index = 0;
                    var pts = db.Patient_Details.ToList();
                    foreach (var pt in pts)
                    {
                        if (pt.Id == Convert.ToInt32(textBox1.Text))
                        {
                            db.Patient_Details.Remove(pt);
                            db.SaveChanges();
                            break;
                        }
                        index++;
                    }
                    MessageBox.Show("Patient Deleted: " + textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Please enter Id...");
                }
            }
            catch
            {
                MessageBox.Show("Please enter correct Id...");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                var pts = db.Patient_Details.ToList();
                foreach (var pt in pts)
                {
                    if (pt.Id == Convert.ToInt32(textBox1.Text))
                    {
                        textBox2.Text = pt.Name;
                        if (pt.Gender == "Male")
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        textBox3.Text = pt.Address;
                        textBox4.Text = pt.PostalCode;
                        textBox5.Text = pt.PhoneNumber;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter Id...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            var pts = db.Patient_Details.ToList();
            textBox1.Text = Convert.ToString(pts.Count() + 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var pts = db.Patient_Details.ToList();

            textBox1.Text = Convert.ToString(pts[0].Id);
            textBox2.Text = pts[0].Name;
            if (pts[0].Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox3.Text = pts[0].Address;
            textBox4.Text = pts[0].PostalCode;
            textBox5.Text = pts[0].PhoneNumber;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var pts = db.Patient_Details.ToList();
            if (textBox1.Text != string.Empty)
            {
                var prevIndex = Convert.ToInt32(textBox1.Text) - 2;
                if (prevIndex <= -1)
                {
                    MessageBox.Show(" No Prev record found...");
                }
                else
                {
                    textBox1.Text = Convert.ToString(pts[prevIndex].Id);
                    textBox2.Text = pts[prevIndex].Name;
                    if (pts[prevIndex].Gender == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    textBox3.Text = pts[prevIndex].Address;
                    textBox4.Text = pts[prevIndex].PostalCode;
                    textBox5.Text = pts[prevIndex].PhoneNumber;
                }

            }
            else
            {
                MessageBox.Show("Please enter Id...");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var pts = db.Patient_Details.ToList();
            if (textBox1.Text != string.Empty)
            {
                var nextIndex = Convert.ToInt32(textBox1.Text);
                if (nextIndex > pts.Count)
                {
                    MessageBox.Show(" No Next record found...");
                }
                else
                {
                    textBox2.Text = pts[nextIndex].Name;
                    if (pts[nextIndex].Gender == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    textBox3.Text = pts[nextIndex].Address;
                    textBox4.Text = pts[nextIndex].PostalCode;
                    textBox5.Text = pts[nextIndex].PhoneNumber;
                }
            }
            else
            {
                MessageBox.Show("Please enter Id...");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var pts = db.Patient_Details.ToList();

            var lastIndex = pts.Count() - 1;
            textBox1.Text = Convert.ToString(pts[lastIndex].Id);
            textBox2.Text = pts[lastIndex].Name;
            if (pts[lastIndex].Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox3.Text = pts[lastIndex].Address;
            textBox4.Text = pts[lastIndex].PostalCode;
            textBox5.Text = pts[lastIndex].PhoneNumber;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var pts = db.Patient_Details.ToList();
            dataGridView1.DataSource = pts;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var pts = db.Patient_Details.ToList();

            if (pts.Count == 0)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = Convert.ToString(pts.Count() + 1);
            }
        }
    }
}
