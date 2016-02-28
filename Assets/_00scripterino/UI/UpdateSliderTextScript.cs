using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets._00scripterino;
using Assets._00scripterino.XML;

public class UpdateSliderTextScript : MonoBehaviour
{

    public Text sliderText;
    public Slider theSlider;

    public string valueToUpdate;



    // Use this for initialization
    void Start()
    {


        theSlider.onValueChanged.AddListener(sliderUpdated);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void sliderUpdated(float arg0)
    {
        if (sliderText != null)
        {


            GameSettings s = GameManager.instance.settings;

            string displayText = "";

            if (valueToUpdate.Equals("time"))
            {
                s.calibTimer = (uint)arg0 * 1000;
                displayText = Convert.ToString(arg0);
            }
            else {

                float min = s.noramlizingMin;
                float max = s.noramlizingMax;

                float distance = Math.Abs(max - min);

                //Debug.Log(distance);
                //Debug.Log((arg0 * distance));
                //Debug.Log(min + (arg0 * distance));

                if (valueToUpdate.Equals("low"))
                {
                    s.lowerThres = arg0;
                    displayText = Convert.ToString(min + (arg0 * distance));
                }
                else if (valueToUpdate.Equals("mid"))
                {
                    s.midThres = arg0;
                    displayText = Convert.ToString(min + (arg0 * distance));
                }
                else if (valueToUpdate.Equals("upper"))
                {
                    s.upperThres = arg0;
                    displayText = Convert.ToString(min + (arg0 * distance));
                }
                else if (valueToUpdate.Equals("decrease"))
                { s.reductionScale = arg0; displayText = Convert.ToString(arg0); }
                else if (valueToUpdate.Equals("increase"))
                { s.increaseScale = arg0; displayText = Convert.ToString(arg0); }


            }

            sliderText.text = displayText;
        }
    }
}
