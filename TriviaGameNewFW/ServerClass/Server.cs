using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TriviaGameFinal
{
    public class Server
    {
        private int MaxPlayers { get; set; }
        private int Port { get; set; }

        private Dictionary<int, Client> clients = new Dictionary<int, Client>();

        private TcpListener TCPListener;

        private void Start(int _MaxPlayers, int _Port)
        {
            MaxPlayers = _MaxPlayers;

            //Als server kamer.
            Port = _Port;

            //Server Starting...
            TCPListener = new TcpListener(IPAddress.Any, Port);
            TCPListener.Start();
            TCPListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            //Server Started...
            //($"Server Started on {port}." kamer nummer...
            Console.WriteLine($"Server started on port {Port}.");
        }

        private void TCPConnectCallback(IAsyncResult _result)
        {
            TcpClient _client = TCPListener.EndAcceptTcpClient(_result);
            TCPListener.BeginAcceptTcpClient(TCPConnectCallback, null);
            Console.WriteLine($"Incoming connection from {_client.Client.RemoteEndPoint}...");

            for (int i = 1; i <= MaxPlayers; i++)
            {
                if (clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(_client);
                    return;
                }
            }
            Console.WriteLine($"{_client.Client.RemoteEndPoint} failed to connect: Server full!");
        }

        private void InitializeServerData()
        {
            for (int i = 1; i <= MaxPlayers; i++)
            {
                clients.Add(i, new Client(i));
            }
        }
    }
}