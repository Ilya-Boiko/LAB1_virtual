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

    private GameObject controller1;
    private GameObject controller2;
    private GameObject controller3;
    private GameObject controller4;

    void Start()
    {
        controller1 = GameObject.Find("Sphere1");
        controller2 = GameObject.Find("Sphere2");
        controller3 = GameObject.Find("Sphere3");
        controller4 = GameObject.Find("Sphere4");
            if (controller1 == null || controller2 == null || controller3 == null || controller4 == null)
            {
                Debug.LogError("controller1 or controller2 or controller3 or controller4 object not found in the scene!");
                return;
            }
    }

    public void OpenDoor()
    {
        bool flValue1 = controller1.GetComponent<ChangeColor_sp>().fl;
        bool flValue2 = controller2.GetComponent<ChangeColor_sp>().fl;
        bool flValue3 = controller3.GetComponent<ChangeColor_sp>().fl;
        bool flValue4 = controller4.GetComponent<ChangeColor_sp>().fl;

        // Debug.Log("fl value: " + flValue1);
        if (open == false && ((!flValue1 && !flValue2) || (!flValue3 && !flValue4)) )
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