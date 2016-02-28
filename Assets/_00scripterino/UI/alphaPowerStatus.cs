using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets._00scripterino;
using System.Collections.Generic;

public class alphaPowerStatus : MonoBehaviour
{



    public Image alphaCircle;
    public Image level1;
    public Image level2;
    public Image level3;
    public Image level4;
    public Image level5;
    public Image level6;
    public Image level7;
    public Image level8;
    public Image level9;
    public Image level10;

    private Image[] powerBars;

    GameManager man = GameManager.instance;

    float t0 = 0f;
    float t1 = GameManager.instance.settings.lowerThres;
    float t2 = GameManager.instance.settings.midThres;
    float t3 = GameManager.instance.settings.upperThres;
    float t4 = GameManager.instance.settings.maxThres;


    float level0_maxScale;
    float level0_scaleRange;

    float level1_maxScale;
    float level1_scaleRange;

    float level2_maxScale;
    float level2_scaleRange;

    float level3_maxScale;
    float level3_scaleRange;

    float lastPower;


    // Use this for initialization
    void Start()
    {

        level0_maxScale = t1;
        level0_scaleRange = t1 - t0;

        level1_maxScale = t2;
        level1_scaleRange = t2 - t1;

        level2_maxScale = t3;
        level2_scaleRange = t3 - t2;

        level3_maxScale = t4;
        level3_scaleRange = t4 - t3;

        lastPower = 0f;

        powerBars = new Image[10];
        powerBars[0] = level1;
        powerBars[1] = level2;
        powerBars[2] = level3;
        powerBars[3] = level4;
        powerBars[4] = level5;
        powerBars[5] = level6;
        powerBars[6] = level7;
        powerBars[7] = level8;
        powerBars[8] = level9;
        powerBars[9] = level10;


    }

    // Update is called once per frame
    void Update()
    {
        //if (lastPower != GameManager.instance.lastPowerNormalized)
        //{
        //    //updateLevel(alphaCircle, level0_maxScale, level0_scaleRange);
        //    //updateLevel(level1, level1_maxScale, level1_scaleRange);
        //    //updateLevel(level2, level2_maxScale, level2_scaleRange);
        //    //updateLevel(level3, level3_maxScale, level3_scaleRange);
        //}

        //int intensity = GameManager.instance.lastIntensity;
        //switch (intensity) {
        //    case (0):
        //        alphaCircle.fillAmount = 1;
        //        level1.fillAmount = 0;
        //        level2.fillAmount = 0;
        //        level3.fillAmount = 0;

        //        break;
        //    case (1):
        //        alphaCircle.fillAmount = 1;
        //        level1.fillAmount = 1;
        //        level2.fillAmount = 0;
        //        level3.fillAmount = 0;
        //        break;
        //    case (2):
        //        alphaCircle.fillAmount = 1;
        //        level1.fillAmount = 1;
        //        level2.fillAmount = 1;
        //        level3.fillAmount = 0;
        //        break;
        //    case (3):
        //        alphaCircle.fillAmount = 1;
        //        level1.fillAmount = 1;
        //        level2.fillAmount = 1;
        //        level3.fillAmount = 1;
        //        break;
        //    default:
        //        break;
        //}

        updatePowerBars();
    }


    void updateLevel(Image level, float maxScale, float scaleRange) {

        float power = GameManager.instance.lastPowerNormalized;

        if (power >= maxScale) { 
            level.fillAmount = 1;
            return;
        }

        float currentPercent = maxScale - power;

        float progess = currentPercent / scaleRange;

        level.fillAmount = progess;
    }

    void updatePowerBars() {
        float power = GameManager.instance.lastPowerNormalized;

        //float currentPercent = maxScale - power;

        //float progess = currentPercent / scaleRange;


        int bars = (int) (power * 10f) - 1;
        //Debug.Log(bars);
        float fillAmount = 1;

        //Debug.Log()


        for (int i = 0; i < powerBars.Length; i++) {
            if (i > bars)
                fillAmount = 0;
            powerBars[i].fillAmount = fillAmount;
        }

    }

    
}
