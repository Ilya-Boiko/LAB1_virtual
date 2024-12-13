using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateStartPos : MonoBehaviour
{
    public Transform Me; // объект для игнорирования
    public Transform Slot; // ссылка на самого себя

    private Vector3 initialPosition; // начальная позиция объекта
    private Quaternion initialRotation; // начальное вращение объекта
    private bool isInTrigger = false; // флаг для отслеживания состояния триггера

    void Start()
    {
        // Сохраняем начальную позицию и вращение объекта
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Slot.name)
        {
            isInTrigger = true;
            //Debug.Log("Entered trigger zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == Slot.name)
        {
            isInTrigger = false;
            //Debug.Log("Exited trigger zone");
        }
    }

    // Функция для возврата объекта в исходную позицию и вращение
    public void ResetToInitialPosition()
    {
        if (!isInTrigger)
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            //Debug.Log("Object returned to initial position and rotation");
        }
        else
        {
            //Debug.Log("Cannot reset position and rotation while in trigger zone");
        }
    }
}
