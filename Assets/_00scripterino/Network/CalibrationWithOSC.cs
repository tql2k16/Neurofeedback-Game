using UnityEngine;
using SharpOSC;
using System.Collections.Generic;
using LinqStatistics;
using System;
using System.IO;
using System.Linq;
using Assets._00scripterino.Util;
using Assets._00scripterino;
using Assets._00scripterino.XML;

public class CalibrationWithOSC : MonoBehaviour
{



    public bool computeEyesOpen;
    public bool computeEyesClosed;

    UDPListener listener;

    List<float> data;
    private string filename;
    private string filenameCallibration;

    private uint startTimeInMs;
    private uint timeIntervalInMs;
    private string subject = "";


    // Use this for initialization
    void Start()
    {
        computeEyesOpen = false;
        computeEyesClosed = false;
        isFinished = false;


        listener = new UDPListener(12003, handleOSC);

        data = new List<float>();

        


        filenameCallibration = "./Assets/PowerLog/Testing/CALLIBRATION" + DateTime.Now.ToFileTimeUtc() + ".csv";

    }

    private void writeHeader4Statistics()
    {
        TextWriter file = new StreamWriter(filenameCallibration, false);

        string header = "Time;DayTimeInMs;PowerValue";
        file.WriteLine("sep=;");
        file.WriteLine(header);
        file.Close();
    }

    private void handleOSC(OscPacket packet)
    {
        OscBundle p = (OscBundle)packet;
        if (p != null)
        {
            //Debug.Log("Receiving OSC");
            int count = 0;
            foreach (OscMessage m in p.Messages)
            {

                HandleOSCMeassage(m, count);
                count++;
            }
        }

    }


    public void computeEyesOpenStatistics()
    {
        if (computeEyesClosed)
            return;


        computeEyesOpen = true;
        startTimeInMs = Util4Everything.getCurrentDayMilliseconds();
        timeIntervalInMs = GameManager.instance.settings.calibTimer;
        subject = GameManager.instance.settings.subjectName;
        data = new List<float>();
        filenameCallibration = "./Assets/PowerLog/Testing/" + subject + "_EyesOpen" + DateTime.Now.ToFileTimeUtc() + ".csv";
        writeHeader4Statistics();

    }

    public void computeEyesClosedStatistics()
    {
        if (computeEyesOpen)
            return;
        computeEyesClosed = true;
        startTimeInMs = Util4Everything.getCurrentDayMilliseconds();
        timeIntervalInMs = GameManager.instance.settings.calibTimer;
        subject = GameManager.instance.settings.subjectName;
        data = new List<float>();
        filenameCallibration = "./Assets/PowerLog/Testing/" + subject + "_EyesClosed_" + DateTime.Now.ToFileTimeUtc() + ".csv";
        writeHeader4Statistics();

    }

    public bool isComputingOpen()
    {
        return computeEyesOpen;
    }

    public bool isComputingClosed()
    {
        return computeEyesClosed;
    }

    public bool isComputing() { return computeEyesOpen || computeEyesClosed; }

    //public bool isComputingFinished() { return isFinished; }
    public bool isFinished;

    private uint lastDistance;
    public uint lastTimeStampDistance()
    {
        return lastDistance;
    }
    // Update is called once per frame
    void Update()
    {

        if (computeEyesOpen || computeEyesClosed)
        {
            //if (data != null && data.Count > 1)
            //    Debug.Log("Mean" + data.RootMeanSquare() + "Dev:" + data.StandardDeviation() + "Variance"+ data.Variance());


            uint currenttime = Util4Everything.getCurrentDayMilliseconds();

            uint distance = currenttime - startTimeInMs;
            lastDistance = distance;

            if (distance > timeIntervalInMs)
            {
                Debug.Log("done");

                writeStatistics();

                computeEyesOpen = false;
                computeEyesClosed = false;
                isFinished = true;

                if (data != null && data.Count > 1)
                    Debug.Log("Mean:" + data.Average() + " Mean^2:" + data.RootMeanSquare() + " Dev:" + data.StandardDeviation() + " Variance:" + data.Variance());

                

            }
            else {
                //Debug.Log("logginggggg");
            }


        }






    }

    private void writeStatistics()
    {
        TextWriter file = new StreamWriter(filenameCallibration, true);

        GameSettings s = GameManager.instance.settings;

        file.Write("Mean");

        file.Write(";");
        file.Write("Squared Mean");
        file.Write(";");
        file.Write("Median");
        file.Write(";");
        file.Write("Deviation");
        file.Write(";");
        file.Write("Variance");
        file.Write(";");
        file.Write("Kurtosis(Steilheit)");
        file.Write(";");
        file.Write("Max");
        file.Write(";");
        file.Write("Min");
        file.Write(";");
        file.Write("Skewness(Schiefe)");
        file.Write(";");
        file.Write("Mode");
        file.Write(";");
        file.Write("Range(Spannweite)");
        file.Write(";");
        file.WriteLine("");

        file.Write(Convert.ToString(data.Average()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.RootMeanSquare()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Median()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.StandardDeviation()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Variance()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Kurtosis()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Max()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Min()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Skewness()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Mode<float>()).Replace('.', ','));
        file.Write(";");
        file.Write(Convert.ToString(data.Range()).Replace('.', ','));
        file.Write(";");
        file.WriteLine("");
        file.Close();

        if (computeEyesOpen)
        {
            s.meanEyesOpen = data.Average();
            s.meanSqrtEyesOpen = data.RootMeanSquare();
            s.deviationEyesOpen = data.StandardDeviation();
            s.varianceEyesOpen = data.Variance();
            s.kurtosisEyesOpen = data.Kurtosis();
            s.maxEyesOpen = data.Max();
            s.minEyesOpen = data.Min();
            s.skewnessEyesOpen = data.Skewness();
            s.rangeEyesOpen = data.Range();

            Debug.Log("writing statistics ..........................");
        }
        else if (computeEyesClosed)
        {
            s.meanEyesClosed = data.Average();
            s.meanSqrtEyesClosed = data.RootMeanSquare();
            s.deviationEyesClosed = data.StandardDeviation();
            s.varianceEyesClosed = data.Variance();
            s.kurtosisEyesClosed = data.Kurtosis();
            s.maxEyesClosed = data.Max();
            s.minEyesClosed = data.Min();
            s.skewnessEyesClosed = data.Skewness();
            s.rangeEyesClosed = data.Range();
        }
    }

    internal void CloseListener()
    {
        listener.Close();
    }

    public void HandleOSCMeassage(OscMessage msg, int msgNumber)
    {


        if (msg.Address.Equals("/power4calibration"))
        {
            foreach (float f in msg.Arguments)
            {
                //res += (f + ",");

                if (computeEyesOpen || computeEyesClosed)
                {
                    float realF;
                    realF = f;

                    data.Add(f);
                    TextWriter file = new StreamWriter(filenameCallibration, true);
                    file.Write(DateTime.Now.TimeOfDay);
                    file.Write(";");
                    file.Write(Util4Everything.getCurrentDayMilliseconds());
                    file.Write(";");
                    file.Write(Convert.ToString(realF).Replace('.', ','));
                    file.Write(";");
                    file.WriteLine("");
                    file.Close();
                }

            }
        }


    }

}
