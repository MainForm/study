using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MillSuppoter
{
    public partial class MainForm : Form
    {
        private SerialPort Com;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Com = new SerialPort();

            this.Com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Com_DataReceived);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {   
            if(Com.IsOpen)
                Com.Close();
        }

        private void 아두이노연결AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnetCom FrmCntCom = new ConnetCom();

            FrmCntCom.ShowDialog();
            if(FrmCntCom.CdnToCnt == 1)
            {
                //Serial 셋팅

                if (ConnectCom(FrmCntCom.ComName,FrmCntCom.Bauad) == -1)
                    MessageBox.Show("아두이노 연결에 실패하였습니다.");
                else
                    Com.Open();

                if (Com.IsOpen == false)
                {
                    MessageBox.Show("연결 안됨");
                }
                else
                {
                    this.Text += " Connected : " + Com.PortName;
                    MessageBox.Show("연결!!");
                }
            }
            else if(FrmCntCom.CdnToCnt == -1){
                MessageBox.Show("해제");
                this.Text = "스마트 병영";
                DisConnectCom();
            }
        }


        public int ConnectCom(string ComNum,int BaudRate)
        {
            try
            {
                Com.PortName = ComNum;
                Com.BaudRate = BaudRate;
                Com.DataBits = 8;
                Com.Parity = Parity.None;
                Com.StopBits = StopBits.One;
            }
            catch{
                return -1;
            }

            return 0;
        }

        public void DisConnectCom()
        {
            Com.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private string Cmd;

        private void Com_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int Msg = sp.ReadChar();
            if (Msg == '\n')
            {
                MessageBox.Show(Cmd);
                Cmd = "";
            }
            else
            {
                Cmd = Cmd + (char)Msg;
                //MessageBox.Show(Cmd + (Char)Msg);
            }
         }

        private void panel1_Click(object sender, EventArgs e)
        {
            Toilet FrmToilet = new Toilet();

            FrmToilet.Show();

        }
    }
}
