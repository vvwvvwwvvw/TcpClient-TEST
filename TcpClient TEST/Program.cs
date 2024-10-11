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
            //TcpClient tcpClient = new TcpClient("127.0.0.1", 8000);
             TcpClient tcpClient = new TcpClient ("localhost", 8080);
            string msg = "Hello World";
            byte[] buffer = Encoding.ASCII.GetBytes(msg);

            // (2) NetworkStream을 얻어옴
            NetworkStream netStream = tcpClient.GetStream();

            //(3) 스트림에 바이트 데이터 전송
            netStream.Write(buffer, 0, buffer.Length);

            //(4) 스트림으로 부터 바이트 데이터 읽기
            byte[] outbuf = new byte[1024];
            int nbytes = netStream.Read(outbuf, 0, outbuf.Length);
            string output = Encoding.ASCII.GetString(outbuf, 0 , nbytes);

            // (5) 스트림과 TcpClient 객체 닫기
            netStream.Close();
            tcpClient.Close();

        }
    }
}
