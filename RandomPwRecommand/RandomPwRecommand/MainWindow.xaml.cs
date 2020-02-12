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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomPwRecommand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pwlist> pwlists;
        AboutSQL aboutSQL;
        string tempstring;
        string tempstring2;
        public MainWindow()
        {
            InitializeComponent();
            pwlists = new List<Pwlist>();
            aboutSQL = new AboutSQL();
            aboutSQL.ConnectDB();
            aboutSQL.CreateDB();
            aboutSQL.CreateTable();
            load_data();
        }

        void load_data()
        {
            Dictionary<string, string> data = aboutSQL.SelectTable_data();
            foreach(KeyValuePair<string,string> valuePair in data)
            {
                pwlists.Add(new Pwlist() { Time = valuePair.Key, Password = valuePair.Value });
                pwlistview.ItemsSource = pwlists;
                pwlistview.Items.Refresh();
            }
        }

        private void btn_recommand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PwRandom pw = new PwRandom(Convert.ToInt32(combobox_pwlength.Text));
                if (checkbox_number.IsChecked == false && checkbox_lowalp.IsChecked == false &&
                    checkbox_higalp.IsChecked == false && checkbox_speci.IsChecked == false)
                {
                    pwblock.Text = "ERROR";
                }
                else
                {
                    pwblock.Text =
                    pw.pwrecommand(checkbox_number.IsChecked == true,
                    checkbox_lowalp.IsChecked == true,
                    checkbox_higalp.IsChecked == true,
                    checkbox_speci.IsChecked == true
                    );
                    textboxPw.Text = pwblock.Text;

                    tempstring = DateTime.Now.ToString();
                    tempstring2 = textboxPw.Text;

                    pwlists.Add(new Pwlist() { Time = tempstring, Password = tempstring2 });
                    pwlistview.ItemsSource = pwlists;
                    pwlistview.Items.Refresh();

                    aboutSQL.InsertTable(tempstring, tempstring2);
                }
            }
            catch
            {
                pwblock.Text = "ERROR";
            }
            
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            aboutSQL.DeleteTableData_all();
            pwlists.Clear();
            pwlistview.ItemsSource = pwlists;
            pwlistview.Items.Refresh();
        }
    }
}
