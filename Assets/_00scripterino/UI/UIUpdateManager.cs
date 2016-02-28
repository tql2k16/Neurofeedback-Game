using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets._00scripterino;
using Assets._00scripterino.XML;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;

public class UIUpdateManager : MonoBehaviour
{

    public Text timeSliderText;
    public Slider timeS;
    public Text lowThresSliderText;
    public Slider lowS;
    public Text midThresSliderText;
    public Slider midS;
    public Text upperThresSliderText;
    public Slider upperS;

    public Text meanO;
    public Text meanOSqrt;
    public Text devO;
    public Text varO;
    public Text maxO;
    public Text minO;
    public Text rangeO;
    public Text kurtosisO;
    public Text skewO;

    public Text meanC;
    public Text meanCSqrt;
    public Text devC;
    public Text varC;
    public Text maxC;
    public Text minC;
    public Text rangeC;
    public Text kurtCsisC;
    public Text skewC;

    public InputField minCrop;
    public InputField maxCrop;
    public InputField subjectCrop;

    public Slider incS;
    public Slider decS;
    public Text incT;
    public Text decT;

    public Toggle onlyReduce;
    public Toggle ignoreLastPower;

    public Dropdown drop;


    List<string> fileNames;
    string currentFile = "settings";
    GameObject callibrationPanel;
    CalibrationWithOSC oscData;



    GameManager m;
    GameSettings s;

    public bool thisIstheMenu = true;

    // Use this for initialization
    void Start()
    {
        m = GameManager.instance;
        s = m.settings;

        if (thisIstheMenu)
        {
            loadValuesIntoUI();
        }

        callibrationPanel = GameObject.FindGameObjectWithTag("CallibrationPanel");
        oscData = callibrationPanel.GetComponent<CalibrationWithOSC>();

        onlyReduce.onValueChanged.AddListener(updateReduceToggle);
        ignoreLastPower.onValueChanged.AddListener(updateIgnoreLastPower);

        string path = "./Assets/Settings/";

        //currentFile = "settings";



        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.xml");

        fileNames = new List<string>();

        foreach (FileInfo f in info)
        {
            fileNames.Add(f.Name);

            //Debug.Log(f.Name);
        }

        



        //   drop.AddOptions(fileNames);

        //drop.onValueChanged.AddListener(dropDownFileListUpdate);
        //drop.


    }

    private void updateIgnoreLastPower(bool arg0)
    {
        s.ignoreLastPower = arg0;
    }

    //private void dropDownFileListUpdate(int arg0)
    //{
    //    if (currentFile.Equals(""))
    //        currentFile = m.settings.subjectName + "settings";
    //    m.storeSettings(Application.dataPath + "/Settings/" + currentFile);

    //    currentFile = fileNames.ToArray()[arg0];

    //     m.settings = XMLReadAndWrite.Deserialize<GameSettings>(Application.dataPath + "/Settings/" + currentFile);

    //    loadValuesIntoUI();
    //}

    private void loadValuesIntoUI()
    {
        timeSliderText.text = Convert.ToString(s.calibTimer / 1000);
        timeS.value = s.calibTimer / 1000;
        lowThresSliderText.text = Convert.ToString(s.lowerThres);
        lowS.value = s.lowerThres;
        midThresSliderText.text = Convert.ToString(s.midThres);
        midS.value = s.midThres;
        upperThresSliderText.text = Convert.ToString(s.upperThres);
        upperS.value = s.upperThres;

        incS.value = s.increaseScale;
        decS.value = s.reductionScale;
        incT.text = Convert.ToString(s.increaseScale);
        decT.text = Convert.ToString(s.reductionScale);

        meanO.text = Convert.ToString(s.meanEyesOpen);
        meanOSqrt.text = Convert.ToString(s.meanSqrtEyesOpen);
        devO.text = Convert.ToString(s.deviationEyesOpen);
        varO.text = Convert.ToString(s.varianceEyesOpen);
        maxO.text = Convert.ToString(s.maxEyesOpen);
        minO.text = Convert.ToString(s.minEyesOpen);
        rangeO.text = Convert.ToString(s.rangeEyesOpen);
        kurtosisO.text = Convert.ToString(s.kurtosisEyesOpen);
        skewO.text = Convert.ToString(s.skewnessEyesOpen);

        meanC.text = Convert.ToString(s.meanEyesClosed);
        meanCSqrt.text = Convert.ToString(s.meanSqrtEyesClosed);
        devC.text = Convert.ToString(s.deviationEyesClosed);
        varC.text = Convert.ToString(s.varianceEyesClosed);
        maxC.text = Convert.ToString(s.maxEyesClosed);
        minC.text = Convert.ToString(s.minEyesClosed);
        rangeC.text = Convert.ToString(s.rangeEyesClosed);
        kurtCsisC.text = Convert.ToString(s.kurtosisEyesClosed);
        skewC.text = Convert.ToString(s.skewnessEyesClosed);

        minCrop.text = Convert.ToString(s.noramlizingMin);
        maxCrop.text = Convert.ToString(s.noramlizingMax);
        subjectCrop.text = s.subjectName;

        onlyReduce.isOn = s.onlyReduceScale;
        ignoreLastPower.isOn = s.ignoreLastPower;

        updateMinMaxCropValues();
    }



    public void loadValuesIntoSettings()
    {
        //s.calibTimer = (uint)timeS.value * 1000;


        //s.lowerThres = lowS.value;

        //s.midThres = midS.value;
        //s.upperThres = upperS.value;

        //s.meanEyesOpen = (float)Convert.ToDouble(meanO.text);
        //s.meanSqrtEyesOpen = (float)Convert.ToDouble(meanOSqrt.text);
        //s.deviationEyesOpen = (float)Convert.ToDouble(devO.text);
        //s.varianceEyesOpen = (float)Convert.ToDouble(varO.text);
        //s.maxEyesOpen = (float)Convert.ToDouble(maxO.text);
        //s.minEyesOpen = (float)Convert.ToDouble(minO.text);
        //s.rangeEyesOpen = (float)Convert.ToDouble(rangeO.text);
        //s.kurtosisEyesOpen = (float)Convert.ToDouble(kurtosisO.text);
        //s.skewnessEyesOpen = (float)Convert.ToDouble(skewO.text);

        //s.meanEyesClosed = (float)Convert.ToDouble(meanC.text);
        //s.meanSqrtEyesClosed = (float)Convert.ToDouble(meanCSqrt.text);
        //s.deviationEyesClosed = (float)Convert.ToDouble(devC.text);
        //s.varianceEyesClosed = (float)Convert.ToDouble(varC.text);
        //s.maxEyesClosed = (float)Convert.ToDouble(maxC.text);
        //s.minEyesClosed = (float)Convert.ToDouble(minC.text);
        //s.rangeEyesClosed = (float)Convert.ToDouble(rangeC.text);
        //s.kurtosisEyesClosed = (float)Convert.ToDouble(kurtCsisC.text);
        //s.skewnessEyesClosed = (float)Convert.ToDouble(skewC.text);
        if (thisIstheMenu)
        {




        }
    }



    public void updateReduceToggle(bool asd) {
        s.onlyReduceScale = asd;
    }

    public void updateSubjectText()
    {
        //if (fileNames.Contains(subjectCrop.text + ".xml"))
        m.settings.subjectName = subjectCrop.text;

        //updateSettingsFile(subjectCrop.text);


    }

    //public void updateSettingsFile(string file) {
    //    if (fileNames.Contains(file+ ".xml"))
    //    {
    //        currentFile = file;
    //        m.settings = XMLReadAndWrite.Deserialize<GameSettings>("./Assets/Settings/" + file);
    //        Debug.Log(s.subjectName);
    //        loadValuesIntoUI();
    //    }
    //    else {
    //        //m.settings.subjectName = subjectCrop.text;
    //        m.storeSettings("./Assets/Settings/" + file);
    //        fileNames.Add(file);
    //        currentFile = file;
    //        Debug.Log("find teh exception");
    //        m.settings = XMLReadAndWrite.Deserialize<GameSettings>("./Assets/Settings/" + file);
    //        loadValuesIntoUI();
    //    }
    //}

    public void updateMinMaxCropValues()
    {
        float min;
        float.TryParse(minCrop.text, out min);
        float max;
        float.TryParse(maxCrop.text, out max);

        s.noramlizingMin = min;
        s.noramlizingMax = max;

        float tmp = lowS.value;
        lowS.value = 0;
        lowS.value = tmp;

        tmp = midS.value;
        midS.value = 0;
        midS.value = tmp;

        tmp = upperS.value;
        upperS.value = 0;
        upperS.value = tmp;
    }


    // Update is called once per frame
    void Update()
    {
        if (oscData.isFinished)
        {
            loadValuesIntoUI();
            oscData.isFinished = false;
        }

    }




    public void loadDopeFishIsFatScene(string s)
    {

        loadValuesIntoSettings();

        oscData.CloseListener();
        GameManager.instance.storeSettings("./Assets/Settings/" + currentFile);

        SceneManager.LoadScene("dopeFishIsFatGame");
    }
    void OnApplicationQuit()
    {

        oscData.CloseListener();
        loadValuesIntoSettings();
        GameManager.instance.storeSettings("./Assets/Settings/" + currentFile);


    }

}
