using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 排班系統
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!= "")
            {
                listBox1.Items.Add(textBox1.Text);
            }
            else
            {
                MessageBox.Show("請輸入員工姓名", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("請選擇刪除對象", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.Insert(listBox1.SelectedIndex, textBox1.Text);
            }
            else
            {
                MessageBox.Show("請選擇插入位置", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "";                       
            Random r = new Random();
            int attendance = 0;
            string[] name = new string[listBox1.Items.Count];
            int[] namm = new int[10];
            //namm[0] = r.Next(1, attendance + 1);

            for (int i = 0; i < listBox1.Items.Count; i++)  //將全部員工姓名加至字串陣列
            {
                name[i] = Convert.ToString(listBox1.Items[i]);
            }
            if (int.TryParse(textBox2.Text, out attendance)&& attendance<=name.Length)
            { //判斷是否為數測並隨機分配上班人員
                for (int i = 0; i < attendance; i++)
                {
                    namm[i] = r.Next(1, listBox1.Items.Count);
                    //MessageBox.Show(name[i] + "=i");
                    for (int j = 0; j < i; j++)
                    {
                        if (namm[i] == namm[j])
                        {
                            namm[i] = r.Next(1, listBox1.Items.Count);
                            j--;
                        }

                    }

                    label2.Text += name[namm[i]] + "\n";
                }
            }
            else
            {
                MessageBox.Show("請輸入正確人數", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int x = 0;
           
            List<int> xyz = new List<int>();

            List<ListBox> listbb = new List<ListBox>();
            listBox2.Items.Clear(); listBox3.Items.Clear(); listBox4.Items.Clear();

            listbb.Add(listBox2); listbb.Add(listBox3); listbb.Add(listBox4);

            for (int i = 0; i < 18 ; i++)         //插入隨機班別
            {
                if (listBox2.Items.Count < 8) //白斑人數未滿足
                {
                    if (listBox3.Items.Count < 6) //白斑未滿小夜斑未滿
                    {
                        if (listBox4.Items.Count < 4)//大夜未滿
                        {
                            x = r.Next(0, 3);  //白斑小夜大夜隨機分配
                        }
                        else
                        {
                            x = r.Next(0, 2);
                            // MessageBox.Show("排班結束");
                        }
                    }
                    else//小夜已滿
                    {
                        if (listBox4.Items.Count < 4)// 白斑未滿小夜已滿大夜未滿
                        {
                            x = r.Next(0, 2);
                            if (x == 1)
                            {
                                x = 2;
                            }
                        }
                        else
                        {
                            x = r.Next(0, 1);
                        }
                    }
                }
                else //白斑人數已滿足
                {
                    if (listBox3.Items.Count < 6)
                    {
                        if (listBox4.Items.Count < 4)
                        {
                            x = r.Next(1, 3);
                        }
                        else
                        {
                            x = r.Next(1,2);
                        }
                    }
                    else
                    {
                        if (listBox4.Items.Count < 4)
                        {
                            x = r.Next(2, 3);
                        }
                        else
                        {
                            MessageBox.Show("排班結束");
                        }
                    }
                }

                xyz.Add(r.Next(1, listBox1.Items.Count));  //插入隨機員工
                for (int z = 0; z < i; z++)
                {
                    if (xyz[i] == xyz[z])
                    {
                        xyz[i] = r.Next(1, listBox1.Items.Count );
                        z--;
                    }
                }
                listbb[x].Items.Add(Convert.ToString(listBox1.Items[xyz[i]]));


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Random r = new Random();
           

            //List<int> xyz = new List<int>();
            //label2.Text = "";
            //for (int y = 0; y < 18; y++)
            //{
            //    xyz.Add(r.Next(1, listBox1.Items.Count+1));
            //    for (int z = 0; z < y; z++)
            //    {
            //        if (xyz[y] == xyz[z])
            //        {
            //            xyz[y] = r.Next(1, listBox1.Items.Count+1);
            //            z--;
            //        }
            //    }
            //    //listbb[x].Items.Add(Convert.ToString(listBox1.Items[xyz[y]]));
            //    label2.Text += xyz[y]+"   ";
            //}
        }
    }
}
