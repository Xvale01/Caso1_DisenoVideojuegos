using System;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

//esta es la estructura que dice como va a girar la camara
[Serializable]
public struct CameraRotation
{
    [SerializeField]
    float pitch; //y

    [SerializeField]
    float yaw;//z

    public float getPitch()
    {
        return pitch;
    }

    public float getYaw()
    {
        return yaw;
    }

    public void setPitch(float value)
    {
        pitch = value;
    }

    public void setYaw(float value)
    {
        yaw = value;
    }
}
