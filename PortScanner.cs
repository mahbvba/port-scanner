using System;
using System.Net;
using System.Net.Sockets;

class PortScanner
{
    static void Main()
    {
        string targetIP;
        int startPort, endPort;

        // user enters the target IP address, starting port and ending port
        Console.Write("Enter the target IP address: ");
        targetIP = Console.ReadLine();

        Console.Write("Enter the starting port: ");
        startPort = int.Parse(Console.ReadLine());

        Console.Write("Enter the ending port: ");
        endPort = int.Parse(Console.ReadLine());

        Console.WriteLine("Scanning ports...");

        for (int port = startPort; port <= endPort; port++)
        {
            if (IsPortOpen(targetIP, port))
            {
                Console.WriteLine($"Port {port} is open.");
            }
        }

        Console.WriteLine("Port scanning complete.");
    }

    static bool IsPortOpen(string ip, int port)
    {
        try
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect(ip, port);
                return true;
            }
        }
        catch (SocketException)
        {
            return false;
        }
    }
}

