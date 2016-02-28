using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._00scripterino.Util
{
    public static class Util4Everything
    {


        static public float getNormalizeValue(float value, float max, float min, float maxScaled, float minScaled)
        {
            return minScaled + (value - min) * (maxScaled - minScaled) / (max - min);
        }

        static public Vector3 getReduceScaleVector(float reduce, float oldScaleX, float oldScaleY, float minScale)
        {
            //float oldScaleX = trans.localScale.x;
            //float oldScaleY = trans.localScale.y;
            float newScaleX = 0.0f, newScaleY = 0.0f;
            if (oldScaleX <= -minScale)
                newScaleX = oldScaleX + reduce;
            if (oldScaleX >= minScale)
                newScaleX = oldScaleX - reduce;

            if (oldScaleY <= -minScale)
                newScaleY = oldScaleY + reduce;
            if (oldScaleY >= minScale)
                newScaleY = oldScaleY - reduce;

            if (newScaleX > -minScale && newScaleX < minScale)
            {
                if (newScaleX < 0)
                    newScaleX = -minScale;
                else
                    newScaleX = minScale;
            }


            if (newScaleY > -minScale && newScaleY < minScale)
            {
                if (newScaleY < 0)
                    newScaleY = -minScale;
                else
                    newScaleY = minScale;
            }



            return new Vector3(newScaleX, newScaleY, 1);
        }

        static public Vector3 getIncreseScaleVector(float increase, float oldScaleX, float oldScaleY, float maxScale, float minScale)
        {
            //float oldScaleX = trans.localScale.x;
            //float oldScaleY = trans.localScale.y;
            float newScaleX = 0.0f, newScaleY = 0.0f;

            // 5f;

            if (oldScaleX < 0)
            {
                if (oldScaleX <= -maxScale)
                    newScaleX = -maxScale;
                else if (oldScaleX <= -minScale)
                    newScaleX = oldScaleX - increase;
            }
            else if (oldScaleX > 0)
            {
                if (oldScaleX >= maxScale)
                    newScaleX = maxScale;
                else if (oldScaleX >= minScale)
                    newScaleX = oldScaleX + increase;
            }

            if (oldScaleY < 0)
            {
                if (oldScaleY <= -maxScale)
                    newScaleY = -maxScale;
                else if (oldScaleY <= -minScale)
                    newScaleY = oldScaleY - increase;
            }
            else if (oldScaleY > 0)
            {
                if (oldScaleY >= maxScale)
                    newScaleY = maxScale;
                else if (oldScaleY >= minScale)
                    newScaleY = oldScaleY + increase;
            }




            //if (oldScaleX <= -maxScale)
            //    newScaleX = oldScaleX - increase;
            //if (oldScaleX >= maxScale)
            //    newScaleX = oldScaleX + increase;

            //if (oldScaleY <= -maxScale)
            //    newScaleY = oldScaleY - increase;
            //if (oldScaleY >= maxScale)
            //    newScaleY = oldScaleY + increase;

            //if (newScaleX > -maxScale || newScaleX < maxScale)
            //{
            //    if (newScaleX < 0)
            //        newScaleX = -maxScale;
            //    else
            //        newScaleX = maxScale;
            //}


            //if (newScaleY > -maxScale || newScaleY < maxScale)
            //{
            //    if (newScaleY < 0)
            //        newScaleY = -maxScale;
            //    else
            //        newScaleY = maxScale;
            //}



            return new Vector3(newScaleX, newScaleY, 1);
        }

        static public uint getCurrentDayMilliseconds()
        {
            uint hour = (uint)DateTime.Now.Hour;
            uint minutes = (uint)DateTime.Now.Minute;
            uint seconds = (uint)DateTime.Now.Second;
            uint ms = (uint)DateTime.Now.Millisecond;

            uint hourToMs = 3660000;
            uint minToMs = 61000;
            uint secondToMs = 1000;

            uint total = hour * hourToMs + minutes * minToMs + seconds * secondToMs + ms;

            return total;
        }
    }
}
