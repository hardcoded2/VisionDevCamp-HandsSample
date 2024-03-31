using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class UDP_Listener : MonoBehaviour
{
    private UdpClient udpClient;
    private CancellationTokenSource cancellationTokenSource;
    private StringBuilder lastReceivedPacket = new StringBuilder();
    
    private Action<Pose> OnShoot;

    public int listenPort = 12347; // Choose your desired port

    async void Start()
    {
        try
        {
            Debug.LogError("Starting udp listener");
            udpClient = new UdpClient(listenPort);
            cancellationTokenSource = new CancellationTokenSource();
            Debug.Log("about to listen udp listener");
            await ReceiveData(cancellationTokenSource.Token);
            Debug.LogError("done udp listener");
        }
        catch (Exception ex)
        {
            Debug.LogError("exception udp listener");
            Debug.LogError(ex);
            Debug.LogException(ex);
        }
    }

    void Update()
    {
        // Handle received data here (e.g., move a cube)
        string packet = Interlocked.Exchange(ref lastReceivedPacket, new StringBuilder()).ToString();
        if (!string.IsNullOrEmpty(packet))
        {
            // Process the packet content (e.g., move the cube)
            Debug.LogError("Received: " + packet);
        }
        else
        {
            Debug.Log("NOTHING");
        }
    }

    async Task ReceiveData(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = (await udpClient.ReceiveAsync()).Buffer;
            string text = Encoding.UTF8.GetString(data);
            lastReceivedPacket.Append(text);
        }
    }

    void OnApplicationQuit()
    {
        try
        {
            cancellationTokenSource.Cancel();
            udpClient.Close();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }
}