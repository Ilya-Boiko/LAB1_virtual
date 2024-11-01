using UnityEngine;

public class MoveP : MonoBehaviour
{
    public float speed = 2f; // Скорость движения
    public float distance = 5f; // Расстояние, которое платформа будет проходить
    
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = true;
    private float pauseTime = 2f; // Время паузы
    private float pauseTimer = 0f; // Таймер паузы
    private bool isPaused = false;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(0, 0, distance);
    }

    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
        else if (isPaused)
        {
            PauseMovement();
        }
    }

    private void MovePlatform()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        
        // Проверяем достигли ли мы цели
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Меняем направление
            isMoving = false;
            isPaused = true;

            // Меняем цель на противоположную
            targetPosition = targetPosition == startPosition ? startPosition + new Vector3(0, 0, distance) : startPosition;
        }
    }

    private void PauseMovement()
    {
        pauseTimer += Time.deltaTime;
        
        // Если время паузы прошло, продолжаем движение
        if (pauseTimer >= pauseTime)
        {
            isPaused = false;
            isMoving = true;
            pauseTimer = 0f; // Сбрасываем таймер
        }
    }
}