using UnityEngine;
using System.Collections;

public class DieScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("dopeFish"))
        {
                //Debug.Log("HELLO");

                playerControler tmp = transform.parent.gameObject.GetComponent<playerControler>();
                tmp.Die();
            
        }

        
    }
}
