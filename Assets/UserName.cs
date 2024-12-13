using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UserName : MonoBehaviour
{
    int numbers = 0;
    string RightCode = "1234";
    string MyName = "";

    public GameObject disablePanel;
    public TextMeshPro NameText;

    public void EnterCode(string Number)
    {
        numbers++;
        MyName += Number; // Изменено на += для правильного формирования кода
        MyName = CapitalizeFirstLetter(MyName); // Гарантируем заглавную букву
        Debug.Log(MyName);
        NameText.text = MyName;
    }

    public void Check()
    {
        Debug.Log("Check");
        if (MyName == RightCode)
        {
            Debug.Log("Nice");
            //сохранить результат 
        }
    }

    public void RemoveLastCharacter()
    {
        if (MyName.Length > 0)
        {
            MyName = MyName.Substring(0, MyName.Length - 1);
            MyName = CapitalizeFirstLetter(MyName); // Обновляем заглавную букву
            NameText.text = MyName;
            Debug.Log(MyName);
        }
    }

    public void ClearName()
    {
        MyName = "";
        NameText.text = MyName;
        Debug.Log("Code cleared");
    }

    // Функция для капитализации первой буквы
    private string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }
}