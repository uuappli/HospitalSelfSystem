using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace RefreshTimeRegister
{
    public partial class GenerateRegInfo : Form
    {
        private RSACryption RSA = new RSACryption();
        private string privateKey = "Skynet", publicKey = "Skynetwww.01.cn";
        public GenerateRegInfo()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string Hashdata = string.Empty, signate = string.Empty;
            RSA.RSAKey(out privateKey, out publicKey);
            StringBuilder enStr = new StringBuilder();
            enStr.Append("RegistrationInfo:|");
            enStr.Append("SKYNET|");
            enStr.Append(dateTimePicker1.Value.ToString() + "|");
            enStr.Append(textBox1.Text.Trim() + "|");
            enStr.Append(publicKey + "|");

            RSA.GetHash(enStr.ToString(), ref Hashdata);

            RSA.SignatureFormatter(privateKey, Hashdata, ref signate);

            string text = AES.AESEncrypt(enStr.ToString() + signate, "23686922SKYNETDEV1F04DFA4DB538");
            string[] Reg = AES.AESDecrypt(text, "23686922SKYNETDEV1F04DFA4DB538").Split('|');
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "激活文件(*.rts)|*.rts";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(text);
                    sw.Flush();
                }
            }
        }

        private void GenerateRegInfo_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            dateTimePicker1.Value = dt;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
    }
}
