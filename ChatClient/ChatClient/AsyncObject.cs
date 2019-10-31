using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class AsyncObject
    {
        public byte[] Buffer;
        public Socket WorkingSocket;
        public int size;
        public AsyncObject(int bufferSize)
        {
            this.size = bufferSize;
            this.Buffer = new byte[size];
        }
        public void inibuffer()
        {
            this.Buffer = null;
            this.Buffer = new byte[size];
        }


        
        
    }
    //https://slaner.tistory.com/52
}
