using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public Color[] color;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReapeatBG",4,4);
    }
    void ReapeatBG()
    {
        int rand = Random.Range(0,color.Length);
        Camera.main.backgroundColor = color[rand];
    }
}
