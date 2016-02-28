using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;

// http://answers.unity3d.com/questions/15422/unity-project-and-3rd-party-apps.html
public class s_TCP : MonoBehaviour
{
    internal Boolean socketReady = false;
    TcpClient mySocket;
    NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;
    String Host = "localhost";
    public Int32 Port = 5678;

    public bool testHeader = true;
    public bool testSignal = false;
    public bool isString = false;
    public int testSampleChannelSize;
    public int testSampleCount;
    public int testChannelCount;

    public double[,] lastMatrix;

    public float power;

    public RawOpenVibeSignal lastSignal;

    Rigidbody2D rb;
    public class RawOpenVibeSignal {

        public int channels;
        public int samples;

        public double[,] signalMatrix;
    }
    void Start()
    {
        setupSocket();
        
    }
    void FixedUpdate()
    {
       power = ((float)readSocket());
        
    }
    // **********************************************
    public void setupSocket()
    {
        try
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e);
        }
    }
    public void writeSocket(string theLine)
    {
        if (!socketReady)
            return;
        String foo = theLine + "\r\n";
        theWriter.Write(foo);
        theWriter.Flush();
    }
    public double readSocket()
    {
        if (!socketReady)
            return 0; // TODO
        if (theStream.DataAvailable)
        {



            // read header once
            if (testHeader)
            {
                readHeader();

            }

            if (testSignal)
                {
                // raw signal data
                // [nSamples x nChannels]
                // all channels for one sample are sent in a sequence, then all channels of the next sample

                // create a signal object to send it to another
                RawOpenVibeSignal newSignal = new RawOpenVibeSignal();
                newSignal.samples = testSampleCount;
                newSignal.channels = testChannelCount;

                double[,] newMatrix = new double[testSampleCount,testChannelCount];

       
                    byte[] buffer = new byte[testSampleChannelSize];

                    theStream.Read(buffer, 0, testSampleChannelSize);


                int row = 0;
                int col = 0;
                    for (int i = 0; i < testSampleCount * testChannelCount * (sizeof(double)); i = i + (sizeof(double) * testChannelCount))
                    { 
                        for (int j = 0; j < testChannelCount * sizeof(double); j = j + sizeof(double))
                        {

                            byte[] temp = new byte[8];

                            for(int k = 0; k < 8; k++)
                            {
                                temp[k] = buffer[i + j + k];
                            }

                        if (BitConverter.IsLittleEndian)
                        {
                           // Array.Reverse(temp);
                            double test = BitConverter.ToDouble(temp, 0);
                           
                            // TODO TEST THIS
                            //newMatrix[i / (8 * testChannelCount), j / 8] = test;
                            newMatrix[row, col] = test;
                        }
                        col++;

                        }
                    row++;
                    col = 0;
                    }

                newSignal.signalMatrix = newMatrix;
                lastSignal = newSignal;
                lastMatrix = newMatrix;

                

               displaySignalText();

                return newMatrix[0, 0];
            }
                else if (isString) {
                    Debug.Log(theReader.ReadLine());
                }

            }
            return 0;

    }

    private void readHeader()
    {
        // size of header is 8 * size of unit = 32 byte

        int variableSize = sizeof(UInt32);
        int variableCount = 8;

        int headerSize = variableCount * variableSize;

        byte[] buffer = new byte[headerSize];

        theStream.Read(buffer, 0, headerSize);

        // version number (in network byte order)
        // endianness of the stream (in network byte order, 0==unknown, 1==little, 2==big, 3==pdp)
        // sampling frequency of the signal, 
        //  number of channels, 
        // number of samples per chunk and 
        // three variables of padding


        UInt32 version, endiannes, frequency, channels, samples;

        byte[] v = new byte[4] { buffer[0], buffer[1], buffer[2], buffer[3] };
        byte[] e = new byte[4] { buffer[4], buffer[5], buffer[6], buffer[7] };
        byte[] f = new byte[4] { buffer[8], buffer[9], buffer[10], buffer[11] };
        byte[] c = new byte[4] { buffer[12], buffer[13], buffer[14], buffer[15] };
        byte[] s = new byte[4] { buffer[16], buffer[17], buffer[18], buffer[19] };
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(e);
            Array.Reverse(v);
            version = BitConverter.ToUInt32(v, 0);
            endiannes = BitConverter.ToUInt32(e, 0);
            frequency = BitConverter.ToUInt32(f, 0);
            channels = BitConverter.ToUInt32(c, 0);
            samples = BitConverter.ToUInt32(s, 0);
        }
        else
        {

            version = 999;
            endiannes = 0;
            frequency = 0;
            channels = 0;
            samples = 0;
        }

       // Debug.Log("Version: " + version + "\n" + "Endiannes: " + endiannes + "\n" + "sampling frequency of the signal: " + frequency + "\n" + "number of channels: " + channels + "\n" + "number of samples per chunk: " + samples + "\n");

        testHeader = false;
        testSampleCount = buffer[16];
        testChannelCount = buffer[12];
        testSampleChannelSize = buffer[12] * buffer[16] * sizeof(double);

        testSignal = true;

        rb = GetComponent<Rigidbody2D>();
    }

    public void closeSocket()
    {
        if (!socketReady)
            return;
        theWriter.Close();
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }

    void displaySignalText() {
        RawOpenVibeSignal s = lastSignal;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < lastSignal.samples; i++) {
            sb.AppendLine("Sample" + i + "\t");
            for (int j = 0; j < lastSignal.channels; j++)
            {
               try
                {
                    sb.AppendLine("Channel" + j).Append(lastSignal.signalMatrix[i, j]);
                }
                catch {
                  Debug.Log("i:" + i + "-j:" + j);
                }
           }
        }

       // Debug.Log(sb.ToString());
        
    }
    void OnApplicationQuit()
    {
        closeSocket();
    }
} // end class s_TCP