using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCamera : MonoBehaviour
{
    public SpriteRenderer background;

    void Start()
    {
        float orthoSize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = orthoSize;
    }

    
}
