using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    public int isDestroyed = 0; 
    private void OnCollisionEnter(Collision coll)
    {
         if (coll.gameObject.name == "Bowling Ball" || coll.gameObject.name == "Bowling Ball(Clone)")
        {
            Destroy(coll.gameObject);
            isDestroyed+=1;
        }
    }
}
