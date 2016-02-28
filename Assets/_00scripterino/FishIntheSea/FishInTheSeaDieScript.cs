using UnityEngine;
using System.Collections;

public class FishInTheSeaDieScript : MonoBehaviour {


    MoveRandom move;

	// Use this for initialization
	void Start () {
        move = GetComponent<MoveRandom>();
	}

    public void Die(float timer) {
        move.movementEnabled = false;
        Destroy(gameObject, timer);
    }
}
