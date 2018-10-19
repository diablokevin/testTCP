using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace testTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region tcp
            //TcpListener server = null;
            //try
            //{
            //    // 设置服务器端口号为 13000，IP地址为127.0.0.1.  
            //    Int32 port = 12345;
            //    IPAddress localAddr = IPAddress.Parse("172.16.0.195");

            //    // 实例化一个服务器侦听端口的对象  
            //    server = new TcpListener(localAddr, port);

            //    // 开始侦听  
            //    server.Start();

            //    // 进入侦听循环  
            //    while (true)
            //    {
            //        Console.WriteLine("Waiting for a connection... ");

            //        // 阻塞式的侦听  
            //        // 得到侦听到的TCP客户端  
            //        TcpClient client = server.AcceptTcpClient();     //AcceptTcpClient()这个函数为阻塞式  
            //                                                         //得到客户端的基本信息  

            //        string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            //        string clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString();
            //        //将其打印在控制台  
            //        Console.WriteLine(clientIP + ":" + clientPort + " Connected!");
            //        //得到这个客户端的输入输出流  
            //        NetworkStream iostream = client.GetStream();
            //        //返回hello world  
            //        string info = "hello world";
            //        byte[] infobyte = new byte[info.Length];
            //        for (int i = 0; i < infobyte.Length; i++)
            //        {
            //            infobyte[i] = Convert.ToByte(info[i]);
            //            //Console.WriteLine(infobyte[i]);  
            //        }
            //        iostream.Write(infobyte, 0, infobyte.Length);

            //    }


            //}
            //catch (SocketException e)
            //{
            //    Console.WriteLine("SocketException: {0}", e);
            //}
            //finally
            //{
            //    // Stop listening for new clients.  
            //    server.Stop();
            //}


            //TcpServer Sever = new TcpServer("172.16.0.195", 12345);
            //Sever.DobeginAccept();

            //Console.WriteLine("listening");

            //Console.ReadKey();
            #endregion


            #region 异步编程
            //FileReader reader = new FileReader(1024);

            //string path = "d:\\test.txt";

            //Console.WriteLine("开始读取文件了...");

            //reader.AsynReadFile(path);

            //Console.WriteLine("我这里还有一大滩事呢.");
            //DoSomething();
            //Console.WriteLine("终于完事了，输入任意键，歇着！");
            //Console.ReadKey();
            #endregion
            #region 同步执行
            //for (int i = 0; i < 100; i++)
            //{
            //    if (i == 50)
            //    {
            //        Console.Write("调用方法TakeAWhile并等待方法执行完成。");
            //        TakeAWhile(1, 3000);
            //        Console.Write("方法TakeAWhile执行完成。。。");
            //    }
            //    Thread.Sleep(30);
            //    Console.Write(".");
            //}
            #endregion

            #region 异步执行
            //Func<int, int, int> d2 = TakeAWhile;

            //IAsyncResult ar = d2.BeginInvoke(1, 3000, null, null);

            //while (!ar.IsCompleted)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}

            //int result = d2.EndInvoke(ar);
            //Console.Write("result:{0}", result);

            //#endregion

            //#region 异步回调
            //Func<int, int, int> d1 = TakeAWhile;
            //d1.BeginInvoke(1, 3000, TakesAWhileCompleted, d1);
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}
            #endregion

            Program p = new Program();
          
            int port = 12345;
            //IPAddress localAddr = IPAddress.Parse("192.168.43.81");
            IPAddress localAddr = IPAddress.Parse("172.16.1.227");
            TcpListener tcpListener;
            TcpClient tcpClient;
          
            tcpListener = new TcpListener(localAddr, port);
            //tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();

            Console.WriteLine("begin listening");
            Console.WriteLine(((IPEndPoint)tcpListener.LocalEndpoint).Address);
            while (true)
            {
                try
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    Thread th = new Thread(p.ProcessConnection);
                    th.Start(tcpClient);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    break;
                }
            }

            Console.ReadKey();


        }

        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取本机IP出错:" + ex.Message);
                return "";
            }
        }

        private static void TakesAWhileCompleted(IAsyncResult ar)
        {
           if(ar==null)
            {
                throw new ArgumentException("ar");
            }
            Func<int, int, int> d1 = (Func<int, int, int>)ar.AsyncState;
            int result = d1.EndInvoke(ar);
            Console.WriteLine("Result:{0}", result);
        }

        static int TakeAWhile(int data, int ms)
        {
            Console.Write("TakesAWhile started");
            Thread.Sleep(ms);
            Console.WriteLine("TakeAWhile Completed");
            return ++data;
        }
        static void DoSomething()
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 10000; i++)
            {
                if (i % 888 == 0)
                {
                    Console.WriteLine("888的倍数：{0}", i);
                }
            }
        }
        class FileReader
        {
            private byte[] Buffer { get; set; }

            public int BufferSize { get; set; }

            public FileReader(int bufferSize)
            {
                this.BufferSize = bufferSize;
                this.Buffer = new byte[BufferSize];
            }

            public void SynsReadFile(string path)
            {
                Console.WriteLine("同步读取文件begin");
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    fs.Read(Buffer, 0, BufferSize);
                    string output = System.Text.Encoding.UTF8.GetString(Buffer);
                    Console.WriteLine("读取的文件信息：{0}", output);
                }

                Console.WriteLine("同步读取文件end");
            }

            public void AsynReadFile(string path)
            {
                Console.WriteLine("异步读取文件begin");

                if(File.Exists(path))
                {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    fs.BeginRead(Buffer, 0, BufferSize, AsyncReadCallback, fs);
                }
                else
                {
                    Console.WriteLine("该文件不存在");
                }
            }

            private void AsyncReadCallback(IAsyncResult ar)
            {
                FileStream stream = ar.AsyncState as FileStream;

                if(stream!=null)
                {
                    Thread.Sleep(1000);
                    stream.EndRead(ar);
                    stream.Close();

                    string output = System.Text.Encoding.UTF8.GetString(Buffer);
                    Console.WriteLine("读取的文件信息：{0}", output);
                }
            }
        }
        public void ProcessConnection(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream networkStream = tcpClient.GetStream();
            BinaryReader br = new BinaryReader(networkStream);
            BinaryWriter bw = new BinaryWriter(networkStream);
            byte[] buffer = new byte[1024];
            Console.WriteLine("connected,IP:{0},PORT:{1}", ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address, ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port);
            while(true)
            {
                try
                {
                   
                    char sReader = br.ReadChar();
                    string s = sReader.ToString();
                    Console.WriteLine(sReader);
                    if(s.Trim()=="!")
                    {
                        string sWriter = "t2.txt=\"Test OK!\"";
                        byte[] bt = new byte[sWriter.Length+3];
                        for(int i=0;i<sWriter.Length;i++)
                        {
                            bt[i] = Convert.ToByte(sWriter[i]);
                           // Console.WriteLine(bt[i]);
                        }
                        for(int i= sWriter.Length;i< sWriter.Length+3;i++)
                        {
                            bt[i] = 255;
                        }

                        bw.Write(bt, 0, sWriter.Length+3);
        
                    }
                    else
                    {
                    //string sWriter = "接收到消息";
                    //bw.Write(sWriter);
                    }

                }
                catch
                {
                    break; 
                }
            }
        }


        public class TcpServer
        {
            public TcpListener listener;

            public TcpClient[] ClientList = new TcpClient[5];

            private int ClientsNum = 0;

            public TcpServer(string ip, int port)
            {
                this.listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
                listener.Start();
            }

            public void DobeginAccept()
            {
                Console.WriteLine("Waitting connection");

                listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClient), listener);
            }

            public void DoAcceptTcpClient(IAsyncResult iar)
            {
                this.listener = (TcpListener)iar.AsyncState;
                TcpClient client = this.listener.EndAcceptTcpClient(iar);
                Console.WriteLine(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString() + "connected");

                ClientList[ClientsNum] = client;

                NetworkStream iostream = client.GetStream();

                string info = "hello";
                byte[] infobyte = new byte[info.Length];
                for (int i = 0; i < info.Length; i++)
                {
                    infobyte[i] = Convert.ToByte(info[i]);

                }

                iostream.Write(infobyte, 0, infobyte.Length);
            }
        }
    
    }
}
