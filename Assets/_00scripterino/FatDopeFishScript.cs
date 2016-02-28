using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets._00scripterino.PowerIntensitiy;
using Assets._00scripterino.XML;
using System.Xml.Serialization;
using System.IO;
using Assets._00scripterino.Util;
using Assets._00scripterino;

public class FatDopeFishScript : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    Transform trans;
    OSCReceiver osc;
    ThresholdBasedIntensity intenstity;
    internal bool gameRunning;


    GameManager manager = GameManager.instance;

    float lastPower = 0f;

    float minScale = 1f;
    float normalScale = 3.5f;

    float maxScale = 5f;
    public void startGame()
    {

        gameRunning = true;
        manager.gameWon = false;

        if (osc == null)
            osc = this.GetComponent<OSCReceiver>();
        if (intenstity == null)
            intenstity = new ThresholdBasedIntensity();



        intenstity.setThresholds(manager.settings.lowerThres, manager.settings.midThres, manager.settings.upperThres, 1f);
        //intenstity.setThresholds(0.5f, 0.8f, 0.95f, 1f);
        minScale = manager.settings.minScale4FatFish;
        normalScale = manager.settings.normalFishScale;


        trans.localScale = new Vector3(normalScale, normalScale, 1f);
        manager.startGame(GameManager.FAT_FISH);

        this.GetComponent<MoveRandom>().movementEnabled = true;
        rb.isKinematic = false;

    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();

        gameRunning = false;

        this.GetComponent<MoveRandom>().movementEnabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameRunning)
        {
            if (isBackToNormal())
            {
                Debug.Log("wonwonwonwonow");
                gameRunning = false;
                this.GetComponent<MoveRandom>().movementEnabled = false;
                this.GetComponent<FlipHorizontalScript>().facingRight = true;
                rb.MovePosition(new Vector2(0, 0));
                rb.isKinematic = true;

                manager.gameWon = true;
                manager.resetGame();

            }
            else {
                float f = osc.getLastNormalizedPower();
                Debug.Log(f);

                //  if (lastPower != f || f > 0.998 || f <= 0.002)

                if (!manager.settings.ignoreLastPower)
                {
                    if (lastPower != f)
                    {
                        // go on
                    }
                    else
                        return;

                }
                    lastPower = f;
                    manager.lastPowerNormalized = lastPower;

                    int intens = intenstity.determineIntensity(f);
                    manager.lastIntensity = intens;




                    float scale = manager.settings.reductionScale * intens;

                    
                    if (scale > 0)
                        ReduceScale(scale);
                    else if (intens == 0 && !manager.settings.onlyReduceScale)
                    {
                        IncreaseScale(manager.settings.increaseScale);
                        
                    }
                

            }

        }
        else
            this.GetComponent<MoveRandom>().movementEnabled = false;
    }

    void ReduceScale(float reduce)
    {


        float oldScaleX = trans.localScale.x;
        float oldScaleY = trans.localScale.y;

        trans.localScale = Util4Everything.getReduceScaleVector(reduce, oldScaleX, oldScaleY, minScale);

    }

    void IncreaseScale(float increase)
    {


        float oldScaleX = trans.localScale.x;
        float oldScaleY = trans.localScale.y;

        trans.localScale = Util4Everything.getIncreseScaleVector(increase, oldScaleX, oldScaleY, maxScale, minScale);

    }


    public bool isBackToNormal()
    {
        float xScale = Math.Abs(trans.localScale.x);
        float yScale = Math.Abs(trans.localScale.y);
        if (xScale <= minScale && yScale <= minScale)
            return true;
        else
            return false;
    }

    public void loadMenuScence() {
        manager.loadMenuScene();
    }
}
