using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatClient
{
    /// <summary>
    /// Dialog_IPadd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Dialog_IPadd : Window
    {
        public Dialog_IPadd()
        {
            InitializeComponent();
        }

        public string getName { get { return txtbox_DialogIPadd_Name.Text; } }

        public string getIP { get { return txtbox_DialogIPadd_IP.Text; } }

        public int getPort { get { return int.Parse(txtbox_DialogIPadd_Port.Text); } }

        private void Btn_DialogIPadd_OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
