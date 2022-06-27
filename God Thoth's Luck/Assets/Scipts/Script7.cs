using UnityEngine;
using System;
using System.Text;
public class Script7 : MonoBehaviour
{
    public static Script7 Mains;
    private void Awake()
    {
        multiPoko();
    }
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
    public string dec(string des)
    {
        string Sde="";
        try
        {
            Sde = Encoding.UTF8.GetString(Convert.FromBase64String(des));
        }
        catch
        {

        }
        return Sde;
    }
}
