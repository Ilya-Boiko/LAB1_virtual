using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText; // Ссылка на текстовый компонент для отображения счета
    public GameObject[] kegles; // Массив всех кеглей на сцене
    public float halfHeightThreshold = 0.5f; // Пороговое значение для определения падения кегли

    private int knockedKegles = 0; // Счетчик сбитых кеглей
    private float[] originalYPositions; // Массив исходных вертикальных позиций кеглей

    void Start()
    {
        // Заполняем массив исходных позиций
        originalYPositions = new float[kegles.Length];
        for (int i = 0; i < kegles.Length; i++)
        {
            originalYPositions[i] = kegles[i].transform.position.y;
        }
    }

    void Update()
    {
        // Проверяем каждую кеглю
        for (int i = 0; i < kegles.Length; i++)
        {
            // Если кегля сбита, но еще не засчитана
            if (Mathf.Abs(kegles[i].transform.position.y - originalYPositions[i]) > halfHeightThreshold && !kegles[i].GetComponent<Kegle>().isKnocked) 
            {
                // Увеличиваем счетчик
                knockedKegles++;
                // Отмечаем кеглю как сбитую
                kegles[i].GetComponent<Kegle>().isKnocked = true;
            }
        }

        // Обновляем текст счетчика
        scoreText.text = "Счет: " + knockedKegles;
    }
}
 
