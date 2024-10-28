
 using UnityEngine;

public class Trigger_test : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject objToSpawn;

    private float timer = 0f;
    private int counter = 0;

    private void Update()
    {
        
        if (timer > 0f)
        {
            timer += Time.deltaTime; 
        }

        
        if (timer >= 2f)
        
        {
            counter+=1;

            if (counter == 1){
                Instantiate(objToSpawn, spawnPoint.position, Quaternion.identity);
                timer = 0f;
            }

            else if (counter == 2){
                counter = 0;
            }

        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.name == "Bowling Ball" || collision.gameObject.name == "Bowling Ball(Clone)")
        {
            timer = 0.1f; 
        }
    }
}
 