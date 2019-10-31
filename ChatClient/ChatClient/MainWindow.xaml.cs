using System;
using System.ComponentModel;
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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Threading;
using System.Threading;

namespace ChatClient
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        string cmd = string.Empty;
        bool IsConnected = false;
        TcpClient tc;
        AboutSqlite sqlite;
        string tempip=string.Empty;
        int tempport = 0;
        int tempcount = 0;
        Thread thread;

        public MainWindow()
        {
            InitializeComponent();
            
            sqlite = new AboutSqlite();
            sqlite.ConnectDB();
            sqlite.CreateDB();
            sqlite.CreateTable();

            table_load();
        }

        public void table_load()
        {
            try
            {
                tempcount = sqlite.SelectTable_count();
                if (tempcount > 0)
                {
                    for (int i = 0; i < tempcount; i++)
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            listbox_IPandName.Items.Add(sqlite.SelectTable_name(i));
                        }));

                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //메시지 전송
        private void Txtbox_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if((KeyStates.Down & Keyboard.GetKeyStates(Key.Enter)) > 0)
            {
                string temp = label_Name.Content + ": " + txtbox_Chat.Text + "\n";
                //txtbox_HistoryChat.Text += temp;
                SendMessage(temp);
                txtbox_Chat.Text = null;
            }
            
        }

        private void Btn_Send_Click(object sender, RoutedEventArgs e)
        {
            string temp = label_Name.Content + ": " + txtbox_Chat.Text + "\n";
            //txtbox_HistoryChat.Text += temp;
            SendMessage(temp);
            txtbox_Chat.Text = null;
        }

        //아이피 삭제
        private void Btn_IPDel_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_IPandName.SelectedIndex >= 0)
            {
                sqlite.DeleteTable(listbox_IPandName.SelectedIndex);
                sqlite.UpdataTable(listbox_IPandName.SelectedIndex, listbox_IPandName.Items.Count);
                listbox_IPandName.Items.RemoveAt(listbox_IPandName.SelectedIndex);
            }
            //SQL DB 삭제
            tempcount = sqlite.SelectTable_count();
        }

        //아이피 추가
        private void Btn_IPAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog_IPadd();
            if (dialog.ShowDialog() == true)
            {
                sqlite.InsertTable(listbox_IPandName.Items.Count, dialog.getName, dialog.getIP, dialog.getPort);
                listbox_IPandName.Items.Add(dialog.getName);
                
                //SQL DB 추가
            }
            tempcount = sqlite.SelectTable_count();
        }

        //Connect IP
        private void Listbox_IPandName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            IsConnected = true;
            btn_ServerClose.IsEnabled = true;
            listbox_IPandName.IsEnabled = false;
            tempip=sqlite.SelectTable_ip(listbox_IPandName.SelectedItem.ToString());
            tempport = sqlite.SelectTable_port(listbox_IPandName.SelectedItem.ToString());
            
            thread = new Thread(ConnectTcpServer);
            thread.IsBackground = true;
            thread.Start();
            
            //출처: https://it-jerryfamily.tistory.com/entry/Program-C-서버클라이언트-채팅-통신 [IT 이야기]
        }
        
        private void SendMessage(string message)
        {
            if (!tc.Connected)
                return;
            byte[] buff = Encoding.Unicode.GetBytes(message);

            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();//TcpClient 전역 변수를 이용 

            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);
        }

        private void ConnectTcpServer()
        {
            
            try
            {
                //string ipaddress = string.Empty;/////SQL DB 아이피값
                //int port=     //SQL DB 포트값
                // (1) IP 주소와 포트를 지정하고 TCP 연결 
                //IPAddress address = IPAddress.Parse(tempip);
                //IPEndPoint endPoint = new IPEndPoint(address, tempport);
                //tc = new TcpClient(endPoint);
                tc = new TcpClient(tempip,tempport);
                //TcpClient tc = new TcpClient("localhost", 7000);

                //string msg = "Hello World";
                //byte[] buff = Encoding.Unicode.GetBytes(msg);

                // (2) NetworkStream을 얻어옴 
                //NetworkStream stream = tc.GetStream();

                // (3) 스트림에 바이트 데이타 전송
                //stream.Write(buff, 0, buff.Length);
                while (IsConnected)
                {
                    NetworkStream stream = tc.GetStream();
                    // (4) 스트림으로부터 바이트 데이타 읽기
                    byte[] outbuf = new byte[1024];
                    int nbytes = stream.Read(outbuf, 0, outbuf.Length);
                    string output = Encoding.Unicode.GetString(outbuf, 0, nbytes);
                    display(output);
                    if (!IsConnected)
                        stream.Close();
                }
                // (5) 스트림과 TcpClient 객체 닫기
                //stream.Close();
                tc.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                 {
                     IsConnected = false;
                     btn_ServerClose.IsEnabled = false;
                     listbox_IPandName.IsEnabled = true;
                 }));
                
                return;
            }
            //Console.WriteLine($"{nbytes} bytes: {output}");
        }//http://www.csharpstudy.com/net/article/4-TCP-클라이언트


        //Disconnect IP
        private void Btn_ServerClose_Click(object sender, RoutedEventArgs e)
        {
            btn_ServerClose.IsEnabled = false;
            IsConnected = false;
            listbox_IPandName.IsEnabled = true;

            string exit = label_Name.Content.ToString() + " 퇴장.";
            byte[] buff = Encoding.Unicode.GetBytes(exit);

            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();//TcpClient 전역 변수를 이용 

            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);
        }

        //Change Name
        private void Btn_ChangeNick_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ChangeNickName();
            if(dialog.ShowDialog()==true)
            {
                label_Name.Content = dialog.getChangeName;
            }
        }
        /*
        private void ConnectServer()
        {
            // (1) 소켓 객체 생성 (TCP 소켓)
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // (2) 서버에 연결
            var ep = new IPEndPoint(GetInternalIPAddress(), 2554);
            sock.Connect(ep);

            
            byte[] receiverBuff = new byte[8192];

            //Console.WriteLine("Connected... Enter Q to exit");

            // Q 를 누를 때까지 계속 Echo 실행
            while (IsConnected)
            {
                byte[] buff = Encoding.Unicode.GetBytes(cmd);

                // (3) 서버에 데이타 전송
                sock.Send(buff, SocketFlags.None);

                // (4) 서버에서 데이타 수신
                int n = sock.Receive(receiverBuff);

                string data = Encoding.Unicode.GetString(receiverBuff, 0, n);
                display(data);
            }

            // (5) 소켓 닫기
            sock.Close();
        }
        */
        public static IPAddress GetInternalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private void display(string message)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                txtbox_HistoryChat.Text += message;
            }
           ));
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            
            //MessageBox.Show("test");
        }
    }
}
