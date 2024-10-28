using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public Transform posOpen;
    public Transform posDefault;
    bool open = false;
    public float smoothTime = 2f; 

    public void OpenDoor()
    {
        if (open == false)
        {
            open = true;
     
        }
    }
    void Update()
    {
        if (open)
        {
            transform.position = Vector3.Lerp(transform.position, posOpen.position, smoothTime * Time.deltaTime);
        }
    }
}
