using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshPro scoreText; // Ссылка на текстовый компонент для отображения счета
    public GameObject keglePrefab; // Префаб кегли для восстановления
    public GameObject[] kegles; // Массив всех кеглей на сцене
    public GameObject DestroyBall;
    public float halfHeightThreshold = 0.02f; // Пороговое значение для определения падения кегли

    public int knockedKegles = 0; // Счетчик сбитых кеглей
    private Vector3[] originalPositions; // Массив исходных позиций кеглей
    private Quaternion[] originalRotations; // Массив исходных углов поворота кеглей
    public Door2 doorScript;

    private float openTime;
    private bool timerStarted = false; // Флаг, означающий, что таймер запущен

    
    void Start()
    {
        // Заполняем массив исходных позиций
        originalPositions = new Vector3[kegles.Length];
        originalRotations = new Quaternion[kegles.Length];
        for (int i = 0; i < kegles.Length; i++)
        {
            originalPositions[i] = kegles[i].transform.position;
            originalRotations[i] = kegles[i].transform.rotation;
        }
    }
    void Update()
    {
        try{
            // Проверяем каждую кеглю
            for (int i = 0; i < kegles.Length; i++)
            {
                
                                    
                if (Mathf.Abs(kegles[i].transform.position.y - originalPositions[i].y) > halfHeightThreshold && !kegles[i].GetComponent<Kegle>().isKnocked)
                {
                    // Увеличиваем счетчик
                    knockedKegles++;
                    // Отмечаем кеглю как сбитую
                    kegles[i].GetComponent<Kegle>().isKnocked = true;
                }
                
            

            }
            // Обновляем текст счетчика
            scoreText.text = "Счет: " + knockedKegles;
            if (knockedKegles == 10)
            {
                doorScript.OpenDoor();
            }
            
            if (!timerStarted && (DestroyBall.GetComponent<DestroyBall>().isDestroyed == 2 || knockedKegles == 10 ))
            {
                timerStarted = true; // Установим таймер как запущенный
                openTime = Time.time; // Запоминаем время начала таймера
                Debug.Log("Таймер стартовал");
                DestroyBall.GetComponent<DestroyBall>().isDestroyed = 0;
            }
            // Проверяем, прошло ли 2 секунды с момента запуска таймера
            if (timerStarted && (Time.time - openTime) >= 2f)
            {
                foreach (GameObject keg in kegles)
                {
                    Destroy(keg);
                }
                Invoke("RestoreKegles", 1f);
            }

            //Debug.Log(knockedKegles);
        }
        catch (MissingReferenceException ex){}
    }
    private void RestoreKegles()
        {
            for (int i = 0; i < originalPositions.Length; i++)
            {
                // Создаем новые кегли на исходных позициях
                var kegleInstance = Instantiate(keglePrefab, originalPositions[i], originalRotations[i]);
                kegleInstance.name = $"Kegle_{i}";

                // Добавляем созданную кеглю в массив
                kegles[i] = kegleInstance;
            }

            // Обнуляем счетчик
            knockedKegles = 0;
            timerStarted = false; // Сбрасываем флаг таймера
        }    
}
 
