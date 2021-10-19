using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Odczyt_parametrow_CTS
{
    class LAN
    {
        private readonly string ip;//field
        private readonly int socket;

        public LAN(string ip_, int socket_)//constructor
        {
            ip = ip_;
            socket = socket_;
        }

        public string SendQuestionAndGetResponse(string question, int responseDelay)
        {
            string response = "";
            byte[] sendmsg = Encoding.ASCII.GetBytes(question);
            byte[] bResponse = new byte[256];
            int responseByteCount = 0;

            IPAddress[] IPs = Dns.GetHostAddresses(ip);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.ReceiveTimeout = responseDelay;

            try
            {
                client.Connect(IPs[0], socket);
                client.Send(sendmsg);
                //Opoznienie(responseDelay);
                responseByteCount = client.Receive(bResponse);

                if (responseByteCount > 0)
                    response = Encoding.UTF8.GetString(bResponse);

                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception ex)
            {
                response = ex.ToString() + Environment.NewLine;
            }
            return response;
        }
    }
}