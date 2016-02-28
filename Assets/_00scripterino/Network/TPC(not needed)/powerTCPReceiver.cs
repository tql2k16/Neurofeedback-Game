using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;

public class powerTCPReceiver : MonoBehaviour
{

    // socket & stream
    internal Boolean socketReady = false;
    TcpClient mySocket;
    NetworkStream theStream;

    // local connection info
    String Host = "localhost";
    public Int32 Port = 5678;


    public float power = 1;


    bool headerDone = false;

    // Use this for initialization
    void Start()
    {

        try
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!headerDone) {
            readHeader();
        }
        else
            readSocket();

    }

    private void readHeader()
    {
        byte[] buffer = new byte[32];

        theStream.Read(buffer, 0, 32);

        headerDone = true;
    }

    void readSocket()
    {
        if (!socketReady || !theStream.DataAvailable)
            return;
        else
        {
            if (theStream.DataAvailable)
            {


                // raw signal data
                // [nSamples x nChannels]
                // all channels for one sample are sent in a sequence, then all channels of the next sample



                byte[] buffer = new byte[8];

                theStream.Read(buffer, 0, 8);

                byte[] temp = new byte[8];

                for (int k = 0; k < 8; k++)
                {
                    temp[k] = buffer[k];
                }

                if (!BitConverter.IsLittleEndian)
                {
                    Debug.Log("readingbuffer");
                    Array.Reverse(temp);
                }

                double test = BitConverter.ToDouble(temp, 0);
                power = (float)test;

            }
        }
    }




    public void closeSocket()
    {
        if (!socketReady)
            return;
        mySocket.Close();
        socketReady = false;
    }

    void OnApplicationQuit()
    {
        closeSocket();
    }
}
