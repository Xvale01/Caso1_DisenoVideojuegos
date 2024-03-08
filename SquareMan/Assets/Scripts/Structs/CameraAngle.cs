
using System;
using UnityEngine;

//esta es la estructura que dice como va a girar la camara
[Serializable]
public class CameraAngle 
{
    [SerializeField]
    float min;

    [SerializeField]
    float max;

    public float getMin()
    {
        return min;
    }

    public float getMax() 
    {
        return max;
    }
}

