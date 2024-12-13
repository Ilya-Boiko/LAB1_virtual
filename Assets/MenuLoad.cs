using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void LoadSceneOne()
    {
        SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }
    
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("HandsDemoScene");
    }

    public void LoadSceneTwo()
    {
        SceneManager.LoadScene("SceneTwo");
    }

    public void LoadSceneThree()
    {
        SceneManager.LoadScene("SceneThree");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
