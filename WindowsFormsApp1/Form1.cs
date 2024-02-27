using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Windows API の SetForegroundWindow 関数の宣言
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                button1.Text = "ON";
                timer1.Enabled = true;
            }
            else
            {
                button1.Text = "OFF";
                timer1.Enabled = false;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // フォームをアクティブにする
            ActivateForm();

            // キー入力のシミュレーション
            SendKeys.Send("Hello");
            textBox1.Clear();
        }

        private void ActivateForm()
        {
            // このフォームのウィンドウハンドルを取得
            IntPtr handle = this.Handle;

            // フォームをアクティブにする
            SetForegroundWindow(handle);
        }
    }
}
