using UnityEngine;
using System.Collections;

public class RandomBubbleSpawner : MonoBehaviour {

    public GameObject bubble;
    public int minBubble = 10, maxBubble = 100;
    public float minGravity = -0.5f, maxGravity = -0.3f;
    public float minMass = 5, MaxMass = 15;
    public float minX = -5, maxX = 5;
    public float minY = -3, maxY = -2;
    public float spawnIntervall = 10;
    float timer;


    // Use this for initialization
    void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            generateRandomBubbles();
            timer = spawnIntervall;
        }
    }


    void generateRandomBubbles() {

        int amount = Random.Range(minBubble, maxBubble);

        for (int i = 0; i <= amount; i++) {
            float g = Random.Range(minGravity, maxGravity);
            float m = Random.Range(minMass, MaxMass);
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            Instantiate(bubble, new Vector3(x, y, 0), Quaternion.identity);

        }

    }
}
