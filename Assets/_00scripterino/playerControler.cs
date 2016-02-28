using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class playerControler : MonoBehaviour
{


    bool facingRight = true;
    float speedMax = 1f;
    Animator anim;
    Rigidbody2D rb;
    Transform trans;
    powerTCPReceiver powerRec;
    s_TCP tcp;
    bool isDead = false;

    public Text t;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        // powerRec = GetComponent<powerTCPReceiver>();
        tcp = GetComponent<s_TCP>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = 0;
            if (tcp.power > 20 && tcp.power < 40)
               moveY = 0;
            else if (tcp.power >= 40 && tcp.power < 60)
                moveY = 1.5f;
            else if (tcp.power >= 60 && tcp.power < 100)
                moveY = 2f;
            else if (tcp.power <= 20)
                //moveY = -1;



                anim.SetFloat("speed", Mathf.Abs(moveX) + Mathf.Abs(moveY));

            rb.AddForce(new Vector2(0, moveY * speedMax));

            if (t != null && moveY != 0)
                t.text = "" + moveY;

            //rb.velocity = new Vector2(moveX * speedMax, rb.velocity.y);

            if (moveX > 0 && !facingRight)
                FlipHorizontal();
            else if (moveX < 0 && facingRight)
                FlipHorizontal();
        }


    }

    void FlipHorizontal()
    {
        facingRight = !facingRight;
        Vector3 tmp = trans.localScale;
        tmp.x *= -1;
        trans.localScale = tmp;
    }

    void FlipVertical()
    {

        Vector3 tmp = transform.localScale;
        tmp.y *= -1;
        transform.localScale = tmp;
    }

    public void Die()
    {
        isDead = true;
        anim.SetBool("isDead", isDead);
        rb.gravityScale = -0.5f;
    }
}
