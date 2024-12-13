using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildTimer : MonoBehaviour
{
    public Transform targetObject; // Объект, за которым следим
    public TextMeshPro timerText; // Ссылка на Text-элемент для отображения таймера
    public GameObject[] objectsToCheck; // Объекты, которые нужно проверить

    private Vector3 initialPosition; // Начальная позиция объекта
    private float startTime; // Время начала таймера
    private bool isTimerRunning = false; // Флаг для отслеживания состояния таймера

    void Start()
    {
        // Сохраняем начальную позицию объекта
        initialPosition = targetObject.position;
    }

    void Update()
    {
        // Проверяем, изменилась ли позиция объекта
        if (targetObject.position != initialPosition && !isTimerRunning)
        {
            // Проверяем, включены ли все коллайдеры
            if (AreAllCollidersEnabled())
            {
                // Запускаем таймер
                Debug.Log("запускаем таймер");
                StartTimer();
            }
        }

        // Обновляем таймер, если он запущен
        if (isTimerRunning)
        {
            // Вычисление текущего времени таймера
            float t = Time.time - startTime;

            // Форматирование времени в минуты и секунды
            string minutes = Mathf.FloorToInt(t / 60).ToString("00");
            string seconds = Mathf.FloorToInt(t % 60).ToString("00");

            // Обновление текста таймера
            timerText.text = minutes + ":" + seconds;

            // Проверяем состояние объектов
            if (AreAllCollidersDisabled() && targetObject.position == initialPosition)
            {
                Debug.Log("останавливаем таймер");
                StopTimer();
            }
        }
    }

    // Метод для запуска таймера
    private void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    // Метод для остановки таймера
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Метод для сброса таймера
    public void ResetTimer()
    {
        startTime = Time.time;
    }

    // Метод для проверки состояния коллайдеров у объектов
    private bool AreAllCollidersEnabled()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            Debug.Log(obj.name);
            Debug.Log(obj.GetComponent<Collider>().enabled);
            if (obj != null && (obj.GetComponent<Collider>() == null || !obj.GetComponent<Collider>().enabled))
            {
                //Debug.Log("коллайдеры не включены");

                return false;
            }
        }
        
        Debug.Log("коллайдеры включены");
        return true;
    }

    private bool AreAllCollidersDisabled()
    {
        // Проверяем, отключены ли коллайдеры у всех объектов
        foreach (GameObject obj in objectsToCheck)
        {
            if (obj != null && obj.GetComponent<Collider>() != null && obj.GetComponent<Collider>().enabled)
            {
                //Debug.Log("коллайдеры включены");
                return false; // Если хотя бы один коллайдер включен, возвращаем false
            }
        }
        Debug.Log("коллайдеры отключены");
        return true; // Если все коллайдеры отключены, возвращаем true
    }
}
