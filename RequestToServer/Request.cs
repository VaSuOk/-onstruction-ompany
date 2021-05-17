using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Media.Imaging;
using Сonstruction_сompany.Users;

namespace Сonstruction_сompany.RequestToServer
{
    public class Request
    {
        #region Data fields
        private const int port = 8888;
        private const string address = "127.0.0.1";
        private TcpClient client;
        private NetworkStream stream;
        private static Request request;
        #endregion
        #region Constructors
        public Request()
        {
            client = new TcpClient(address, port);
            stream = client.GetStream();
        }
        public static Request Get_Instance() { return request == null ? request = new Request() : request; }
        #endregion
        #region Methods
        public short RequestWithoutReceivingData(string Data)
        {
            try
            {
                while (true)
                {
                    byte[] data = Encoding.Unicode.GetBytes(Data);
                    stream.Write(data, 0, data.Length);

                    data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    return Convert.ToInt16(builder.ToString());
                }
            }
            catch
            {
                //запис в логи
                return -1;
            }
            finally
            {
                //if (client != null) client.Close();
            }
        }
        public User GetUserInfo(string Data)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(Data);
                stream.Write(data, 0, data.Length);

                data = new byte[64];
                int bytes = 0;
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                int size = Convert.ToInt32(builder.ToString());
                
                builder.Clear();
                
                //stream.Write(data, 0, data.Length);
                data = new byte[size];

                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, data.Length));
                }
                while (stream.DataAvailable);
                
                string message = builder.ToString();
                string[] user_data = message.Split(':');
                User user = new User(Convert.ToUInt32(user_data[0]), User.ConvertToEnum(user_data[1]), user_data[2],
                    user_data[3], user_data[4], user_data[5]/*, Convert.ToInt32(user_data[6]), user_data[7], user_data[8],
                    Encoding.Unicode.GetBytes(user_data[9] )*/);

                return user;
            }
            catch
            {
                //throw;
                //запис в логи
                return new User();
            }
            finally
            {
                //if (client != null) client.Close();
            }
        }
        public BitmapImage Test(string Data)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                while (true)
                {
                    byte[] data = Encoding.Unicode.GetBytes(Data);
                    stream.Write(data, 0, data.Length);

                    data = new byte[64];
                    int bytes = 0;
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    int size = Convert.ToInt32(builder.ToString());
                    data = new byte[size];

                    stream.Write(data, 0, data.Length);
                    
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                    }
                    while (stream.DataAvailable);
                    

                    var imageSource = new BitmapImage();
                    MemoryStream ms = new System.IO.MemoryStream(data);
                    imageSource.BeginInit();
                    imageSource.StreamSource = ms;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();

                    return imageSource; 
                }
            }
            catch
            {
                //запис в логи
                return null;
            }
            finally
            {
                
            }
        }
        #endregion
    }
}
