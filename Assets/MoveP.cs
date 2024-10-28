using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    public float Speed = 3f;
    private Vector3 initialPosition;
    private bool isMoving = true; 
    private float pauseTimer = 2f; 
    private Vector3 moveDirection = Vector3.forward;

    private void Start()
    {
        initialPosition = transform.position; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent = transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }

    void Update()
    {
        // Если платформа должна быть остановлена
        if (!isMoving)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0)
            {
                pauseTimer = 2f; 
                isMoving = true; // Возобновляем движение после паузы
            }
            return; 
        }

        // Проверка границ и смена направления
        if (transform.position.z >= 17.5f || transform.position.z <= initialPosition.z)
        {
            // Меняем направление движения
            moveDirection = -moveDirection;
            isMoving = false; // Останавливаем движение для паузы
            pauseTimer = 2f; // Сбрасываем таймер паузы
        }

        Vector3 movement = moveDirection * Speed * Time.deltaTime; // Включаем скорость в направление движения
        transform.position += movement; // Перемещаем платформу
    }
}
