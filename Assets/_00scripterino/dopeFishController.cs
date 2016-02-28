using UnityEngine;
using System.Collections;

public class dopeFishController : MonoBehaviour {



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("thePlayer"))
        {
         
        } else if (other.tag.Equals("hungryBite")){

        }

    }
}
