using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowsFormsApp3
{
    
    public partial class Form1 : Form
    {
        ServiceHost host;
        string address = "net.tcp://localhost:8080/ServiceSQL/";
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        
        [ServiceContract]
        public interface IMyContract
        {
            [OperationContract]
            string Hello(string name);
        }

        // 실제로 Client에서 호출될 함수
        public class MyService : IMyContract
        {
            public string Hello(string name)
            {
                return "Hello " + name + "!";
            }
        }
        

        private void btn_start_Click(object sender, EventArgs e)
        {

            NetTcpBinding binding = new NetTcpBinding();
            binding.CloseTimeout = new TimeSpan(24, 0, 0);
            binding.OpenTimeout = new TimeSpan(24, 0, 0);
            binding.SendTimeout = new TimeSpan(24, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(24, 0, 0);
            host = new ServiceHost(typeof(ServiceSQL));
            //host = new ServiceHost(typeof(MyService));
            //host.AddServiceEndpoint(typeof(IMyContract), binding, address);
            host.AddServiceEndpoint(typeof(IMySQL), binding, address);
            host.Open();

            label1.Text = "WCF Service Start.";
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            host.Close();
            label1.Text = "WCF Service Stop.";
        }
    }
}
