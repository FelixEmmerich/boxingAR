using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class LoadScores : MonoBehaviour
{
	static string filestring = Application.persistentDataPath+@"/highscore.boxing";

    [System.Serializable]
    public class HighscoreData:IComparable<HighscoreData>
    {
        public string Name;
        public float Time;
        public HighscoreData(string name, float time)
        {
            Name = name;
            Time = time;
        }
        public int CompareTo(HighscoreData other)
        {
            return Time.CompareTo(other.Time);
        }
    }

    public static int AddToHighscore(string name, float time)
    {
        List<HighscoreData> list = LoadHighscore();
        int position=AddHighscoreDataToList(new HighscoreData(name, time), ref list);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filestring, FileMode.OpenOrCreate);
        bf.Serialize(file, list);
        file.Close();
        return position;
    }

    public static List<HighscoreData> LoadHighscore()
    {
        if (File.Exists(filestring))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filestring, FileMode.Open);
            List<HighscoreData>list = (List<HighscoreData>)bf.Deserialize(file);
            file.Close();
            return list;
        }
        Debug.Log("File can't be loaded: " + filestring + " doesn't exist");
        return new List<HighscoreData>();
    }

    public static int AddHighscoreDataToList(HighscoreData hsd, ref List<HighscoreData> list)
    {
        list.Add(hsd);
        list.Sort();
        return list.IndexOf(hsd);
    }
}

