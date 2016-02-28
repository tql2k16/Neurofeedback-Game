using UnityEngine;
using System.Collections;

public class animFish : MonoBehaviour {
    Animator anim;
    Rigidbody2D rb;

    bool facingRight = true;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }
}
