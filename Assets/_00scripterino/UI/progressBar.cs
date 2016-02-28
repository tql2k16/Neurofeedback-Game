using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class progressBar : MonoBehaviour
{

    public Image foregroundImage;
    public Text text;
    GameObject dopeFish;
    Transform dopeTrans;
   
    float maxScale;
    float scaleRange;

    bool gameRunning = false;

    public void startGame()
    {

        gameRunning = true;
       // foregroundImage = gameObject.GetComponent<Image>();
        if (foregroundImage != null)
            //Debug.Log("FUCK");

        Value = 0;

        dopeFish = GameObject.FindWithTag("dopeFish");
        dopeTrans = dopeFish.GetComponent<Transform>();

        maxScale = Math.Abs(dopeTrans.localScale.x);
        scaleRange = maxScale - 1f;

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

    void Start()
    {
       

    }

    void Update()
    {
        if(gameRunning) { 
        if (Value < 1)
        {
            float currentPercent = maxScale - Math.Abs(dopeTrans.localScale.x);

            float progess = currentPercent / scaleRange;
            //Debug.Log("progress" + progess);
            Value = progess;
        }
        else
            Value = 1;
        }

        if(text != null)
            text.text = Math.Round((double)(Value * 100)) + " %";
    }
}
