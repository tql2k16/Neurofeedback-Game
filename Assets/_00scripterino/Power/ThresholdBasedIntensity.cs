using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets._00scripterino.PowerIntensitiy
{
    [XmlRoot("Root")]
    public class ThresholdBasedIntensity
    {
        int lastIntensity;
        float lastpower;


        // XML Settings
        [XmlElement("lowerThreshold")]
        public float lowerThres;
        [XmlElement("midThreshold")]
        public float midThres;
        [XmlElement("upperThreshold")]
        public float upperThres;
        [XmlElement("maxValue")]
        public float maxValue;

        public ThresholdBasedIntensity()
        {
            lastpower = 0;
            lastIntensity = 0;
        }



        // percent please
        public void setThresholds(float first, float second, float third, float max)
        {
            lowerThres = first;
            midThres = second;
            upperThres = third;
            maxValue = max;
        }

        public int determineIntensity(float power)
        {

            int intensity = 0;

            if (power >= lowerThres && power < midThres)
                intensity = 1;
            else if (power >= midThres && power < upperThres)
                intensity = 2;
            else if (power >= upperThres && power < maxValue)
                intensity = 3;
            else
                intensity = 0;

            //if (power > maxValue)
            //    intensity = -1;
            //else

            lastIntensity = intensity;
            lastpower = power;

            return intensity;
        }







    }
}
