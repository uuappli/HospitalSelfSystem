using System;
using System.Windows.Forms;
using HospitalSelfSystem.Register;
using System.IO;
using System.Text;

namespace HospitalSelfSystem
{
    public partial class FrmReg : Form
    {
        private RegHelper reg = new RegHelper();
        public FrmReg()
        {
            InitializeComponent();
        }

        private void FrmReg_Load(object sender, EventArgs e)
        {
            txtMachineCode.Text = reg.MachineCode;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtMachineCode.Text);
        }

   

        private void btnActive_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "激活文件(*.rts)|*.rts";
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string text = string.Empty;
                    using (StreamReader sr = new StreamReader(open.FileName, System.Text.Encoding.UTF8))
                    {
                        text = sr.ReadToEnd();
                    }

                    RegHelper reg = new RegHelper();
                    if (reg.IsCheckOut(text))
                    {
                        MessageBox.Show("注册成功", "提示");
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("注册失败，请检查注册信息", "提示");
                    }
                 


                    //RegHelper helper = new RegHelper();
                    //string RegInfo = Register.DESEncrypt.Decrypt(text);
                    //helper.SetRegInfo(RegInfo.Split('|')[1], RegInfo.Split('|')[2], RegInfo.Split('|')[3], RegInfo.Split('|')[4]);
                    //if (helper.CheckInfo() && helper.IsValidity() && helper.IsCurrent())
                    //{
                    //    MessageBox.Show("注册成功", "提示");
                    //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //}
                    //else
                    //    MessageBox.Show("授权信息不正确，请确认注册信息！", "提示");
                }
                
            }
            catch
            {
                MessageBox.Show("授权信息不正确，请确认注册信息！", "提示");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
