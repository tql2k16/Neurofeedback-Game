using UnityEngine;
using System.Collections;

public class bubbleCollider : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("bubble")) {
            Destroy(other.GetComponent<SpriteRenderer>());
            Destroy(other);
        }
            
    }
}
