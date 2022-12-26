using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

/*
 * Hiper Delete Tool (HDT)
 * by Kormimeiko
 */

namespace HDT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string hiperFilePath_HMCL = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.hmcl\libraries\hiper\hiper\binary\hiper.exe";
        string hiperPath_HMCL = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.hmcl\libraries\hiper";
        string hiperFilePath_HMCL_U1 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.u1\libraries\hiper\hiper\binary\hiper.exe";
        string hiperPath_HMCL_U1 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.u1\libraries\hiper";
        int hmclFlag = 0;
        int u1Flag = 0;

        string hiperFilePath_PCL = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\PCL\联机模块\HiPer 联机模块.exe";
        private void MainForm_Load(object sender, EventArgs e)
        {
            label4.Text = Environment.UserName;
            label12.Text = Environment.UserName;
            CheckHiperFile_HMCL();
            CheckHiperFile_HMCL_U1();
            CheckHiperFile_PCL();
            label9.Text = Application.ProductVersion.ToString();
        }
        public void CheckHiperFile_HMCL()
        {
            if (File.Exists(hiperFilePath_HMCL))
            {
                hmclFlag = 1;
                label6.ForeColor = Color.Red;
                label6.Text = "存在";
                button1.Enabled = true;
                button1.Text = "删除Hiper";
            }
            else
            {
                label6.ForeColor = Color.Green;
                label6.Text = "不存在";
                button1.Enabled = false;
                button1.Text = "太好了，你的计算机中没有发现Hiper核心文件";
            }
        }
        public void CheckHiperFile_HMCL_U1()
        {
            if (File.Exists(hiperFilePath_HMCL_U1))
            {
                u1Flag = 1;
                label6.ForeColor = Color.Red;
                label6.Text = "存在(U1)";
                button1.Enabled = true;
                button1.Text = "删除Hiper";
            }
            else
            {
                label6.ForeColor = Color.Green;
                label6.Text = "不存在";
                button1.Enabled = false;
                button1.Text = "太好了，你的计算机中没有发现Hiper核心文件";
            }
        }
        public void CheckHiperFile_PCL()
        {
            if (File.Exists(hiperFilePath_PCL))
            {
                label14.ForeColor = Color.Red;
                label14.Text = "存在";
                button5.Enabled = true;
                button5.Text = "删除Hiper";
            }
            else
            {
                label14.ForeColor = Color.Green;
                label14.Text = "不存在";
                button5.Enabled = false;
                button5.Text = "太好了，你的计算机中没有发现Hiper核心文件";
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/huanghongxun/HMCL/releases");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://hmcl.huangyuhui.net/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckHiperFile_HMCL();
            CheckHiperFile_HMCL_U1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(hmclFlag ==1 && u1Flag == 1)
                {
                    Directory.Delete(hiperPath_HMCL, true);
                    Directory.Delete(hiperPath_HMCL_U1, true);
                    CheckHiperFile_HMCL();
                    CheckHiperFile_HMCL_U1();
                    MessageBox.Show("已删除Hiper。以下是被删除的目录(包括其中的文件)。请下载原版HMCL。\n\n被删除的目录:\n" + hiperPath_HMCL + "\n" + hiperPath_HMCL_U1, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(hmclFlag == 1)
                {
                    Directory.Delete(hiperPath_HMCL, true);
                    CheckHiperFile_HMCL();
                    MessageBox.Show("已删除Hiper。以下是被删除的目录(包括其中的文件)。请下载原版HMCL。\n\n被删除的目录:\n" + hiperPath_HMCL, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(u1Flag == 1)
                {
                    Directory.Delete(hiperPath_HMCL_U1, true);
                    CheckHiperFile_HMCL_U1();
                    MessageBox.Show("已删除Hiper。以下是被删除的目录(包括其中的文件)。请下载原版HMCL。\n\n被删除的目录:\n" + hiperPath_HMCL_U1, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("删除失败捏。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/KormiMeiko/HiperDeleteTool");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckHiperFile_PCL();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.Delete(hiperFilePath_PCL);
            CheckHiperFile_PCL();
            MessageBox.Show("已删除Hiper。以下是被删除的文件。请下载原版PCL。\n\n被删除的文件:\n" + hiperFilePath_PCL, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Hex-Dragon/PCL2/releases");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://afdian.net/p/0164034c016c11ebafcb52540025c377");
        }
    }
}
