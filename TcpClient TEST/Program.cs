using System;
using System.Net.Sockets;
using System.Text;

namespace TcpClient_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // (1) IP 주소와 포트를 지정하고 TCP 연결
            TcpClient tcpClient = new TcpClient("127.0.0.1", 8000);
            // TcpClient tcpClient = new TcpClient tcpClient("localhost", 8000);
            string msg = "Hello World";
            byte[] buffer = Encoding.ASCII.GetBytes(msg);

            // (2) 
        }
    }
}
