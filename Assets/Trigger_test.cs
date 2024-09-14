
 using UnityEngine;

public class Trigger_test : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject objToSpawn;

    private float timer = 0f;
    private int counter = 0;

    private void Update()
    {
        // Increment timer if outside
        if (timer > 0f)
        {
            timer += Time.deltaTime; 
        }

        // Respawn after 2 seconds outside the zone
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
        // Debug.Log("вышел!");
        // Debug.Log(collision.name);
        // Debug.Log(objToSpawn.name);

        Debug.Log(collision.gameObject.name);
        // Check if the exiting object is the one we're tracking
        if (collision.gameObject.name == "Bowling Ball" || collision.gameObject.name == "Bowling Ball(Clone)")
        {
            
            // Start the timer when the object exits
            timer = 0.1f; 
        }
    }
}
 