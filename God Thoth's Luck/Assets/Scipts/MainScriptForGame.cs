using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using UnityEngine.Networking;


public class MainScriptForGame : MonoBehaviour
{
    public bool[] ready={false,false,false};
    public static MainScriptForGame Mains;
    public string oneSigId;
    public string devKey;
    public string ADB = "null";
    public string TMZ = "null";
    public string s64 = "null";
    public string STR = "null";
    public int Tic=0;
    public string[] value = { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null" };
    public string saveLinka = "";
    public string gaid = "null";
    public string[] par = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    void multiPoko()
    {
        if (Mains == null)
        {
            DontDestroyOnLoad(gameObject);
            Mains = this;
        }
        else if (Mains != this)
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        DataControll("Load");
        multiPoko();
    }

    public void DataControll(string status)
    {
        if (status == "Save")
        {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
            DataSaves data = new DataSaves();
            data.saveLinka = saveLinka;
            data.Tic = Tic;
            binForm.Serialize(file, data);
            file.Close();
        }
        else if (status == "Load")
        {
            if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
            {
                BinaryFormatter binForm = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
                DataSaves data = (DataSaves)binForm.Deserialize(file);
                saveLinka = data.saveLinka;
                Tic = data.Tic;
                file.Close();
            }
        }
    }
}
[Serializable]
class DataSaves
{
    public string saveLinka;
    public int Tic;
}
