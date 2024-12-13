using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CustomAK : MonoBehaviour
{
    public Transform IgnoreComponent; // объект для игнорирования
    public Transform Me; // ссылка на самого себя

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Me.name)
        {
            //Debug.Log("enter");
            //IgnoreComponent.gameObject.SetActive(false);
            IgnoreComponent.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("exit");
        //IgnoreComponent.gameObject.SetActive(true);
        IgnoreComponent.gameObject.GetComponent<Collider>().enabled = true;
    }
}