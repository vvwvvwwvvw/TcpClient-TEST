using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClient_TEST
{
    internal class Class1
    {
        static void Main2(string[] args)
        {
            // (1) IP 주소와 포트를 지정하고 TCP 연결             
            TcpClient tc = new TcpClient("localhost", 7000);

            string msg = "Hello World";
            byte[] buff = Encoding.ASCII.GetBytes(msg);

            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();

            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);

            // (4) 서버가 Connection을 닫을 때가지 읽는 경우
            byte[] outbuf = new byte[1024];
            int nbytes;
            MemoryStream mem = new MemoryStream();
            while ((nbytes = stream.Read(outbuf, 0, outbuf.Length)) > 0)
            {
                mem.Write(outbuf, 0, nbytes);
            }
            byte[] outbytes = mem.ToArray();
            mem.Close();

            // (5) 스트림과 TcpClient 객체 닫기
            stream.Close();
            tc.Close();

            Console.WriteLine(Encoding.ASCII.GetString(outbytes));
        }
    }
}
