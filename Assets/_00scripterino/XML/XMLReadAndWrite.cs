using Assets._00scripterino.PowerIntensitiy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets._00scripterino.XML
{
    public static class XMLReadAndWrite
    {

        //static public void Serialize(ThresholdBasedIntensity approach, string path)
        //{

        //    if (path.Equals(""))
        //        path = @"C:\Xml.xml";

        //    XmlSerializer serializer = new XmlSerializer(typeof(ThresholdBasedIntensity));
        //    using (TextWriter writer = new StreamWriter(@"C:\Xml.xml"))
        //    {
        //        serializer.Serialize(writer, approach);
        //    }
        //}

        //static public void Deserialize(String path)
        //{
        //    if (path.Equals(""))
        //        path = @"C:\Xml.xml";
        //    XmlSerializer deserializer = new XmlSerializer(typeof(ThresholdBasedIntensity));
        //    TextReader reader = new StreamReader(path);
        //    object obj = deserializer.Deserialize(reader);
        //    ThresholdBasedIntensity XmlData = (ThresholdBasedIntensity)obj;
        //    reader.Close();
        //}


        static public void Serialize<T>(T approach, string path)
        {
            if (path.Equals(""))
                path = @"C:\Xml.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(path + ".xml"))
            {
                serializer.Serialize(writer, approach);
            }
        }

        static public T Deserialize<T>(String path)
        {
            if (path.Equals(""))
                path = @"C:\Xml.xml";
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader reader = new StreamReader(path+".xml");
            object obj = deserializer.Deserialize(reader);
            T XmlData = (T)obj;
            reader.Close();

            return XmlData;
        }
    }

   
}
