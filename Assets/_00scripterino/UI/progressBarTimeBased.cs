using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets._00scripterino;
using System;

public class progressBarTimeBased : MonoBehaviour
{


    public Image foregroundImage;
    public Text text;
    GameObject callibrationPanel;
    CalibrationWithOSC oscData;
    float maxScale;

    public bool isOpen;

    GameManager man;

    // Use this for initialization
    void Start()
    {
        man = GameManager.instance;
        callibrationPanel = GameObject.FindGameObjectWithTag("CallibrationPanel");
        oscData = callibrationPanel.GetComponent<CalibrationWithOSC>();
        maxScale = man.settings.calibTimer;
    }

    // Update is called once per frame
    void Update()
    {

        if (oscData != null && oscData.isComputing())
        {
            //if (Value < 1)
            //{

            if (isOpen == oscData.isComputingOpen())
            {

                float currentPercent = oscData.lastTimeStampDistance();

                // 30 - 20
                // = 10 -> 2/3 finished
                // 10 / 30 -> 1/3
                // aber 30 - (30 - 20) = 20

                // 60 - 20
                // = 40 -> 1/3 finished
                // 40 / 60 -> 2/3


                float progess = currentPercent / man.settings.calibTimer;
                //Debug.Log("progress" + progess);
                Value = progess;
                //}
                //else
                //    Value = 1;
            }
        }

        if (text != null)
            text.text = Math.Round((double)(Value * 100)) + " %";

    }

    public float Value
    {
        get
        {
            if (foregroundImage != null)
                return foregroundImage.fillAmount;
            else
                return 0;
        }
        set
        {
            if (foregroundImage != null)
                foregroundImage.fillAmount = value;

        }
    }
}
