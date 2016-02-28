using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets._00scripterino.XML
{
    [XmlRoot("Root")]
    public class GameSettings
    {


        // Game Settings
        [XmlElement("playSound")]
        public bool playSound ;

        [XmlElement("onlyReduceScale")]
        public bool onlyReduceScale ;

        [XmlElement("ignoreLastPower")]
        public bool ignoreLastPower;


        [XmlElement("subjectName")]
        public string subjectName ;


        // intensity
        [XmlElement("lowerThreshold")]
        public float lowerThres ;
        [XmlElement("midThreshold")]
        public float midThres ;
        [XmlElement("upperThreshold")]
        public float upperThres ;
        [XmlElement("maxThreshold")]
        public float maxThres ;

        // fat fish scaleing
        [XmlElement("minScale4FatFish")]
        public float minScale4FatFish ;

        [XmlElement("maxScale4FatFish")]
        public float maxScale4FatFish ;

        [XmlElement("reductionScale")]
        public float reductionScale ;


        [XmlElement("increaseScale")]
        public float increaseScale ;

        [XmlElement("normalFishScale")]
        public float normalFishScale ;

        // normalizing
        [XmlElement("noramlizingMax")]
        public float noramlizingMax ;

        [XmlElement("noramlizingMin")]
        public float noramlizingMin ;


        public int samples4Normalizing ;
        public bool dynamicMax4Normalizing ;
        public bool dynamicMin4Normalizing ;


        // statistics
        [XmlElement("calibTimer")]
        public uint calibTimer ;

        [XmlElement("meanEyesOpen")]
        public float meanEyesOpen ;

        [XmlElement("meanSqrtEyesOpen")]
        public float meanSqrtEyesOpen ;

        [XmlElement("deviationEyesOpen")]
        public float deviationEyesOpen ;

        [XmlElement("varianceEyesOpen")]
        public float varianceEyesOpen ;

        [XmlElement("maxEyesOpen")]
        public float maxEyesOpen ;

        [XmlElement("minEyesOpen")]
        public float minEyesOpen ;

        [XmlElement("rangeEyesOpen")]
        public float rangeEyesOpen ;

        [XmlElement("kurtosisEyesOpen")]
        public float kurtosisEyesOpen ;

        [XmlElement("skewnessEyesOpen")]
        public float skewnessEyesOpen ;


        [XmlElement("meanEyesClosed")]
        public float meanEyesClosed ;

        [XmlElement("meanSqrtEyesClosed")]
        public float meanSqrtEyesClosed ;

        [XmlElement("deviationEyesClosed")]
        public float deviationEyesClosed ;

        [XmlElement("varianceEyesClosed")]
        public float varianceEyesClosed ;

        [XmlElement("maxEyesClosed")]
        public float maxEyesClosed ;

        [XmlElement("minEyesClosed")]
        public float minEyesClosed ;

        [XmlElement("rangeEyesClosed")]
        public float rangeEyesClosed ;

        [XmlElement("kurtosisEyesClosed")]
        public float kurtosisEyesClosed ;

        [XmlElement("skewnessEyesClosed")]
        public float skewnessEyesClosed ;


    }
}

/*Game Settings
        [XmlElement("playSound")]
        public bool playSound { get; internal set; }

[XmlElement("onlyReduceScale")]
public bool onlyReduceScale { get; internal set; }


[XmlElement("subjectName")]
public string subjectName { get; internal set; }


// intensity
[XmlElement("lowerThreshold")]
public float lowerThres { get; internal set; }
[XmlElement("midThreshold")]
public float midThres { get; internal set; }
[XmlElement("upperThreshold")]
public float upperThres { get; internal set; }
[XmlElement("maxThreshold")]
public float maxThres { get; internal set; }

// fat fish scaleing
[XmlElement("minScale4FatFish")]
public float minScale4FatFish { get; internal set; }

[XmlElement("maxScale4FatFish")]
public float maxScale4FatFish { get; internal set; }

[XmlElement("reductionScale")]
public float reductionScale { get; internal set; }


[XmlElement("increaseScale")]
public float increaseScale { get; internal set; }

[XmlElement("normalFishScale")]
public float normalFishScale { get; internal set; }

// normalizing
[XmlElement("noramlizingMax")]
public float noramlizingMax { get; internal set; }

[XmlElement("noramlizingMin")]
public float noramlizingMin { get; internal set; }
public int samples4Normalizing { get; internal set; }
public bool dynamicMax4Normalizing { get; internal set; }
public bool dynamicMin4Normalizing { get; internal set; }


// statistics
[XmlElement("calibTimer")]
public uint calibTimer { get; internal set; }

[XmlElement("meanEyesOpen")]
public float meanEyesOpen { get; internal set; }

[XmlElement("meanSqrtEyesOpen")]
public float meanSqrtEyesOpen { get; internal set; }

[XmlElement("deviationEyesOpen")]
public float deviationEyesOpen { get; internal set; }

[XmlElement("varianceEyesOpen")]
public float varianceEyesOpen { get; internal set; }

[XmlElement("maxEyesOpen")]
public float maxEyesOpen { get; internal set; }

[XmlElement("minEyesOpen")]
public float minEyesOpen { get; internal set; }

[XmlElement("rangeEyesOpen")]
public float rangeEyesOpen { get; internal set; }

[XmlElement("kurtosisEyesOpen")]
public float kurtosisEyesOpen { get; internal set; }

[XmlElement("skewnessEyesOpen")]
public float skewnessEyesOpen { get; internal set; }


[XmlElement("meanEyesClosed")]
public float meanEyesClosed { get; internal set; }

[XmlElement("meanSqrtEyesClosed")]
public float meanSqrtEyesClosed { get; internal set; }

[XmlElement("deviationEyesClosed")]
public float deviationEyesClosed { get; internal set; }

[XmlElement("varianceEyesClosed")]
public float varianceEyesClosed { get; internal set; }

[XmlElement("maxEyesClosed")]
public float maxEyesClosed { get; internal set; }

[XmlElement("minEyesClosed")]
public float minEyesClosed { get; internal set; }

[XmlElement("rangeEyesClosed")]
public float rangeEyesClosed { get; internal set; }

[XmlElement("kurtosisEyesClosed")]
public float kurtosisEyesClosed { get; internal set; }

[XmlElement("skewnessEyesClosed")]
public float skewnessEyesClosed { get; internal set; }
*/
