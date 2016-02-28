using Assets._00scripterino.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._00scripterino.Power
{
    public class PowerData
    {

        int sampleSize = 1000;
        List<float> powerSamples;

        float max, min, maxScaled, minScaled;
        bool dynamicMax = false;
        bool dynamicMin = false;

        GameManager manager = GameManager.instance;

        public float lastPowerNormalized { get; set; }


        public PowerData()
        {

            powerSamples = new List<float>();
            //sampleSize = GameManager.instance.settings.samples4Normalizing;
            //dynamicMax  = GameManager.instance.settings.dynamicMax4Normalizing;
            //dynamicMin = GameManager.instance.settings.dynamicMin4Normalizing;
            max = manager.settings.noramlizingMax;
            min = manager.settings.noramlizingMin;
            minScaled = 0f;
            maxScaled = 1f;
            lastPowerNormalized = 0f;



        }


        public void add(float power)
        {

            if (powerSamples.Count >= sampleSize)
            {
                powerSamples.RemoveAt(0);
            }

            powerSamples.Add(power);

            if (dynamicMax)
                max = powerSamples.Max();
            else
                max = manager.settings.noramlizingMax;

            if (dynamicMin)
                min = powerSamples.Min();
            else
                min = manager.settings.noramlizingMin;



            lastPowerNormalized = Util4Everything.getNormalizeValue(power, max, min, maxScaled, minScaled);
        }
    }









}
