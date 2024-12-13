using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour 
{
 public GameObject Player; 
 public GameObject TeleportTo; 
 
 private void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.CompareTag("Teleporter")) 
        {
            // Player.transform.position = TeleportTo.transform.position; 
            SceneManager.LoadScene("GameOverScene");
        }
        if (collision.gameObject.CompareTag("Teleporter1")) 
        {
            // Player.transform.position = TeleportTo.transform.position; 
            SceneManager.LoadScene("GameOverSceneTwo");
        }
    }
}