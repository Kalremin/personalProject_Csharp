using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ChatClient
{
    class ConnectChat
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;

        
        public void SendMessage(string text)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush(); //내용 전송
        }
        public void GetMessage()
        {
            while(true)
            {
                stream = clientSocket.GetStream();
                int buffersize = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[buffersize];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                message = Encoding.Unicode.GetString(buffer, 0, bytes);
                
            }
        }

        private void Display(string message, string name)
        {
            
        }

        public ConnectChat()
        {

        }
        public static string GetInternalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
    //출처: https://yeolco.tistory.com/53 [열코의 프로그래밍 일기]
}
