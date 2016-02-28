using UnityEngine;
using System.Collections;
using System;

public class SomeFishIsLeaving : MonoBehaviour {


    Transform trans;

	// Use this for initialization
	void Start () {

        trans = this.GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Math.Abs(trans.position.x) > 7f || Math.Abs(trans.position.y) > 7f) {
            GameObject.Destroy(this.gameObject);


            //Debug.Log("destory");
        }
            


    }
}
