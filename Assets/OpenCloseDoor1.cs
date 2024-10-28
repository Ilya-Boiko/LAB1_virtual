using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public Transform posOpen;
    public Transform posDefault;
    bool open = false;
    private float openTime;
    public float smoothTime = 2f; 

    private GameObject controller;

    void Start()
    {
        controller = GameObject.Find("Sphere1");
                if (controller == null)
        {
            Debug.LogError("Controller object not found in the scene!");
            return;
        }

    }

    public void OpenDoor()
    {
        bool flValue = controller.GetComponent<ChangeColor_sp>().fl;
        Debug.Log("fl value: " + flValue);
        if (open == false && !flValue)
        {
            open = true;
            openTime = Time.time; // Запоминаем время открытия
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
        // Проверяем, прошло ли 5 секунд с момента открытия
        if (open && (Time.time - openTime) >= 10f)
        {
            CloseDoor();
        }

        // Плавная смена позиции
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