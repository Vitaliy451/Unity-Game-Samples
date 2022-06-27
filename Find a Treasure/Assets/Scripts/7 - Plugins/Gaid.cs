using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaid : MonoBehaviour
{
    public string GAID;
    // Start is called before the first frame update
    void Start()
    {
        Application.RequestAdvertisingIdentifierAsync((string advertisingId, bool trackingEnabled, string error) => { GAID = advertisingId; print(GAID +" - log GAID"); }); 
    }

}
