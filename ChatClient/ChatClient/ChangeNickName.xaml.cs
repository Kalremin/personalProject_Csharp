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
    /// ChangeName.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChangeNickName : Window
    {
        public ChangeNickName()
        {
            InitializeComponent();
        }

        public string getChangeName { get { return txtbox_DialogChange_ChangeName.Text; } }

        private void Btn_DialogChange_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
