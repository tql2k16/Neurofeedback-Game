using UnityEngine;
using System.Collections;

public class MoveRandom : MonoBehaviour {


    Rigidbody2D rb;
    public bool movementEnabled
    {
        get; set;
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        movementEnabled = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (movementEnabled)
            moveRandom();

    }


    void moveRandom()
    {
        int move = UnityEngine.Random.Range(0, 2);
        if (move == 1)
        {
            int up = UnityEngine.Random.Range(0, 2);
            int left = UnityEngine.Random.Range(0, 2);

            float moveUpDown = UnityEngine.Random.Range(5, 20);
            float moveLeftRight = UnityEngine.Random.Range(5, 20);

            float moveX = 0.0f;
            float moveY = 0.0f;

            if (up == 0)
                moveUpDown *= -1f;
            if (left == 0)
                moveLeftRight *= -1f;

            moveX = moveLeftRight;
            moveY = moveUpDown;

            //Debug.Log("addforce("+ up + "," + left+")"+"force:("+moveX+","+moveY+")");
            rb.AddForce(new Vector2(moveX, moveY));
        }
    }
}
