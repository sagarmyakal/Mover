using System.Runtime.InteropServices;

namespace CursorMover
{
    public partial class Form1 : Form
    {
        bool isOdd = false;
        int timer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Timer"]);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        

        public void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event((uint)MouseEventFlags.LEFTDOWN | (uint)MouseEventFlags.LEFTUP, X, Y, 0, 0);
        }

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = timer;
            timer1.Enabled = false;
            lblMessage.Text = "Not started......";
            lblMessage.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            lblMessage.Text = "Started......";
            lblMessage.ForeColor = Color.Green;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 100, Cursor.Position.Y - 100);
            Cursor.Position = new Point(Cursor.Position.X + 100, Cursor.Position.Y + 100);
            DoMouseClick();
            //if (isOdd)
            //{
            //    Cursor = new Cursor(Cursor.Current.Handle);
            //    Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);                  
            //}
            //else 
            //{
            //    Cursor = new Cursor(Cursor.Current.Handle);                
            //    Cursor.Position = new Point(Cursor.Position.X + 50, Cursor.Position.Y + 50);
            //}
            //isOdd = !isOdd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lblMessage.Text = "Not started......";
            lblMessage.ForeColor = Color.Red;
        }
    }
}