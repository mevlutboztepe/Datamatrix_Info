using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unikod_TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        public void button1_Click(object sender, EventArgs e)
        {
            try
            {

                textBox2.Clear();               
                dataGridView1.Rows.Clear();
                List<string> textboxlines = new List<string>(textBox1.Lines);
                string gtin, seri_number, skt, lot_number;
                List<string> serialnumberlist = new List<string>();

                foreach (var lines in textboxlines)
                {
                    
                    if (lines == null || lines == "")
                    {

                        continue;
                    }

                    else if (lines.Trim().Substring(0, 2) == "01" && lines.Trim().Substring(16, 2) == "21" && lines.Trim().Substring(33, 2) == "17" && lines.Trim().Substring(41, 2) == "10")
                    {

                        // 01 08699514092476 21 260734000995099 17 230228 10 21C623   
                        // 01 05909991439705 21 HKVP108EF36TYK 17 241031 10 21L378
                        gtin = lines.Substring(2, 14).ToString();
                        seri_number = lines.Substring(18, 15).ToString();
                        skt = lines.Substring(39, 2).ToString() + "/" + lines.Substring(37, 2).ToString() + "/" + lines.Substring(35, 2).ToString();
                        lot_number = lines.Substring(43, 6).ToString();
                        serialnumberlist.Add(seri_number);
                        string[] bilgiler = { gtin, seri_number, skt, lot_number };
                        dataGridView1.Rows.Add(bilgiler);


                    }
                    else if (lines.Trim().Substring(0, 2) == "01" && lines.Trim().Substring(16, 2) == "21" && lines.Trim().Substring(34, 2) == "17" && lines.Trim().Substring(42, 2) == "10")
                    {
                        gtin = lines.Substring(2, 14).ToString();
                        seri_number = lines.Substring(18, 16).ToString();
                        skt = lines.Substring(40, 2).ToString() + "/" + lines.Substring(38, 2).ToString() + "/" + lines.Substring(36, 2).ToString();
                        lot_number = lines.Substring(44, 6).ToString();
                        serialnumberlist.Add(seri_number);
                        string[] bilgiler = { gtin, seri_number, skt, lot_number };
                        dataGridView1.Rows.Add(bilgiler);

                    }
                    else if (lines.Trim().Substring(0, 2) == "01" && lines.Trim().Substring(16, 2) == "21" && lines.Trim().Substring(32, 2) == "17" && lines.Trim().Substring(40, 2) == "10")
                    {
                        gtin = lines.Substring(2, 14).ToString();
                        seri_number = lines.Substring(18, 14).ToString();
                        skt = lines.Substring(38, 2).ToString() + "/" + lines.Substring(36, 2).ToString() + "/" + lines.Substring(34, 2).ToString();
                        lot_number = lines.Substring(42, 6).ToString();
                        serialnumberlist.Add(seri_number);
                        string[] bilgiler = { gtin, seri_number, skt, lot_number };
                        dataGridView1.Rows.Add(bilgiler);

                    }


                    else
                    {
                        MessageBox.Show(lines + "Kare Kodu Hatalı");
                    
                    }
                }
                foreach (var item in serialnumberlist)
                {
                    textBox2.AppendText(item + Environment.NewLine);
                }

                lbl_count.Text = serialnumberlist.Count.ToString();
           
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            dataGridView1.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
