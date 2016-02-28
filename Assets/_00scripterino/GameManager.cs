using Assets._00scripterino.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._00scripterino
{
    public class GameManager
    {

        protected GameManager()
        {
            loadSettings();
        }


        public static string FAT_FISH = "DopefishIsFatGame";
        public static string FAT_FISH_MENU = "DopefishIsFatMENU";

        private string currentGame;

        private static GameManager _instance;
        public static GameManager instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();

                return _instance;
            }

        }

        private void loadSettings()
        {
            //settings = new GameSettings();
            //settings.reductionScale = 0.01f;
            //settings.lowerThres = 0.2f;
            //settings.midThres = 0.8f;
            //settings.upperThres = 0.95f;
            //settings.maxThres = 1f;
            //settings.minScale4FatFish = 1f;
            //settings.maxScale4FatFish = 5f;
            //settings.noramlizingMax = 0.53f;
            //settings.noramlizingMin = 0f;
            //settings.dynamicMax4Normalizing = false;
            //settings.dynamicMin4Normalizing = true;
            //settings.samples4Normalizing = 10;
            //settings.normalFishScale = 3.5f;
            //// TODODODODOD
            //settings.calibTimer = 3000;

            
            if(settings == null) { 
                settings = XMLReadAndWrite.Deserialize<GameSettings>("./Assets/Settings/settings");
                //settings = XMLReadAndWrite.Deserialize<GameSettings>(UIUpdateManager.appPath+ "/Settings/" + settings.subjectName);
            }



            //TODO Setttings default ???
        }


        //private GameSettings _settings;
        //public GameSettings settings { get{

        //        if (settings != null)
        //            return _settings;
        //        else { 
        //            loadSettings();
        //            return _settings;
        //        }
        //    }
        //    set {
        //        _settings = value;
        //    } }

        public GameSettings settings { get; set; }
        // for start game button
        Vector3 oldPos;

        public bool gameWon { get; internal set; }


        public float lastPowerNormalized { get; set; }
        public int lastIntensity { get; set; }


        public void startGame(string game)
        {
            gameWon = false;



            // reset labels

            if (game.Equals(FAT_FISH))
            {
                currentGame = FAT_FISH;

                GameObject obj = GameObject.FindWithTag("Menu");
                RectTransform r = obj.GetComponent<RectTransform>();
                oldPos = r.position;
                r.position = new Vector3(10, 10);


            }


        }


        public void resetGame()
        {


            if (currentGame.Equals(FAT_FISH))
            {
                GameObject obj = GameObject.FindWithTag("Menu");
                RectTransform r = obj.GetComponent<RectTransform>();
                r.position = oldPos;

                GameObject obj2 = GameObject.FindWithTag("progressBar");

            }


        }

        public void loadMenuScene() {

            GameObject obj2 = GameObject.FindWithTag("dopeFish");
            OSCReceiver osc = obj2.GetComponent<OSCReceiver>();
            osc.changeScene();

            SceneManager.LoadScene("dopeFishIsFatMenu");
        }

        internal void storeSettings(string path)
        {
            string p;
            if (path.Equals(""))
                p = "./fisherino_Data/Settings/settings";
            else
                p = path;
            XMLReadAndWrite.Serialize<GameSettings>(settings, p);
        }
    }

   


}








