using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalSelfSystem
{
    public class MyMsg
    {
        public static void MsgInfo(string msg)
        {
            FrmWarn m = new FrmWarn();
            m.lblMsg.Text = msg;
            m.ShowDialog();
        }
    }
}
