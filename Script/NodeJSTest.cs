using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeJSTest : MonoBehaviour
{
    void Start()
    {
        UDPTest();
    }
    void UDPTest()
    {
        UdpClient client = new UdpClient(5600);
        try
        {
            client.Connect("127.0.0.1", 5500);
            byte[] sendBytes = Encoding.ASCII.GetBytes("Hello, from the client");
            client.Send(sendBytes, sendBytes.Length);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 5500);
            byte[] receiveBytes = client.Receive(ref remoteEndPoint);
            string receivedString = Encoding.ASCII.GetString(receiveBytes);
            print("Message received from the server \n " + receivedString);
        }
        catch (Exception e)
        {
            print("Exception thrown " + e.Message);
        }
    }
}