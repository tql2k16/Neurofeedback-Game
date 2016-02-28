using UnityEngine;
using System.Collections;
using SharpOSC;
using Assets._00scripterino.Power;
using Assets._00scripterino.Network;
using System.IO;
using System;
using Assets._00scripterino.Util;
using Assets._00scripterino;

public class OSCReceiver : MonoBehaviour
{

    // UDPListener listener;
    PowerData powerData;
    UDPListener listener;

    string filename;

    public int port;

    // Use this for initialization

    void Start()
    {
        //Debug.Log("ayyysdasd");
        listener = new UDPListener(12003, handleOSC);
        
        powerData = new PowerData();
        //filename = Application.dataPath + "/PowerLog/AlphaLog/"+ GameManager.instance.settings.subjectName+ "_" + DateTime.Now.ToFileTimeUtc() + ".csv";
        //Debug.Log(Application.dataPath);
        writeHeader();

    }

    private void handleOSC(OscPacket packet)
    {

        OscBundle p = (OscBundle)packet;
        if (p != null)
        {
            
            int count = 0;
            foreach (OscMessage m in p.Messages)
            {
                HandleOSCMeassage(m, count);
                count++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //handleOSC(listener.Receive());
    }

    public void HandleOSCMeassage(OscMessage msg, int msgNumber)
    {

        if (msg.Address.Equals("/power4game"))
        {
            string res = "Sample " + msgNumber + ": (";

            //TextWriter file = new StreamWriter(filename, true);

            
            foreach (float f in msg.Arguments)
            {
                res += (f + ",");
                powerData.add(f);

                //try
                //{
                //    file.Write(DateTime.Now.TimeOfDay);
                //    file.Write(";");
                //    file.Write(Util4Everything.getCurrentDayMilliseconds());
                //    file.Write(";");
                //    file.Write(f.ToString().Replace(".", ","));
                //    file.Write(";");
                //    file.Write(getLastNormalizedPower().ToString().Replace(".", ","));
                //    file.WriteLine("");

                //}
                //catch { }
            }

            res += ")";
            //file.Close();



            //Debug.Log(res);

        }
    }

    public float getLastNormalizedPower()
    {

        //if (powerData == null)
        //    powerData = new PowerData();
        return powerData.lastPowerNormalized;
    }


    void writeHeader()
    {

        //TextWriter file = new StreamWriter(filename, false);

        //string header = "Time;DayTimeInMs;PowerValue;PowerNormalized";
        //file.WriteLine("sep=;");
        //file.WriteLine(header);
        //file.Close();

    }

    public void changeScene() {
        listener.Close();
    }


}
