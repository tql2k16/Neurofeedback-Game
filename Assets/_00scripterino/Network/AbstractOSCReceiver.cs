using SharpOSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._00scripterino.Network
{
    public abstract class AbstractOSCReceiver : MonoBehaviour
    {
        protected UDPListener listener;
        //PowerData powerData = new PowerData();

        public int port {
            get; set; }

        // Use this for initialization
        protected void Start()
        {

            listener = new UDPListener(port);
            port = -1;

            //  powerData = new PowerData();

        }

        // Update is called once per frame
        protected void Update()
        {
            if (port == -1)
                port = 12001;
            OscBundle p = (OscBundle)listener.Receive();
            if (p != null)
            {
                Debug.Log("Receiving OSC");
                int count = 0;
                foreach (OscMessage m in p.Messages)
                {

                    HandleOSCMeassage(m, count);
                    count++;
                }
            }


        }

        abstract public void HandleOSCMeassage(OscMessage msg, int msgNumber);
    }
}
