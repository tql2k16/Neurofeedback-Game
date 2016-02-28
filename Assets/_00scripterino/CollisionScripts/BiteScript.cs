using UnityEngine;
using System.Collections;

public class BiteScript : MonoBehaviour
{

    public Animator anim;

    float timer = 0;
    bool eating = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("thePlayer") || other.tag.Equals("fishFood"))
        {

            if (anim != null)
            {

                if (eating)
                {
                    timer -= Time.fixedDeltaTime;

                    if (timer < 0) {
                        
                        MoveRandom move = gameObject.GetComponentInParent<MoveRandom>();
                        //move.movementEnabled = true;
                       // Destroy(other.gameObject);
                        eating = false;
                        anim.ResetTrigger("eating");
                    }

                }
                else {
                    eating = true;
                    MoveRandom move = gameObject.GetComponentInParent<MoveRandom>();
                    move.movementEnabled = false;
                    anim.SetTrigger("eating");
                    timer = 1;
                    other.gameObject.GetComponent<FishInTheSeaDieScript>().Die(timer);
                }
            }

        }
        else {
            //Debug.Log("No Collision");
        }



    }
}
