using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform posOpen;
    public Transform posDefault;
    bool open = false;
    private float openTime;
    public float smoothTime = 2f; 

    public void OpenDoor()
    {
        if (open == false)
        {
            open = true;
            openTime = Time.time; 
        }
    }

    public void CloseDoor()
    {
        if (open == true)
        {
            open = false;
        }
    }

    void Update()
    {
        
        if (open && (Time.time - openTime) >= 10f)
        {
            CloseDoor();
        }

        if (open)
        {
            transform.position = Vector3.Lerp(transform.position, posOpen.position, smoothTime * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, posDefault.position, smoothTime * Time.deltaTime);
        }
    }
}
