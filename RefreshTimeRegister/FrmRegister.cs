using System.Windows.Forms;
using System.IO;
using System.Text;

namespace RefreshTimeRegister
{
    public partial class FrmRegister : Form
    {
        private RegHelper reg = new RegHelper();
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void FrmActive_Load(object sender, System.EventArgs e)
        {
            txtMachineCode.Text = reg.MachineCode;
        }

        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetDataObject(txtMachineCode.Text);
        }

        private void btnActive_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                FileStream fs = File.OpenRead(openFileDialog1.FileName);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                MessageBox.Show(reg.IsCheckOut(Encoding.UTF8.GetString(buffer)) ? "注册成功" : "注册失败，请检查注册信息", "提示");
            }
        }

        private void btnHelp_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
