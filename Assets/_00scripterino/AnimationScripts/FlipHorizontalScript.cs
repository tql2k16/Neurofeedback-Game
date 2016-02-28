using UnityEngine;
using System.Collections;

public class FlipHorizontalScript : MonoBehaviour {

    Rigidbody2D rb;
    Transform trans;
    public bool facingRight = true;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.velocity.x > 0 && !facingRight)
            FlipHorizontal();
        else if (rb.velocity.x < 0 && facingRight)
            FlipHorizontal();
    }

    void FlipHorizontal()
    {
        facingRight = !facingRight;
        Vector3 tmp = trans.localScale;
        tmp.x *= -1;
        trans.localScale = tmp;
    }
}
