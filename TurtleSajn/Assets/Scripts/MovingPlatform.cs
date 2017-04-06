using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float speed = 1;
    public int direction = 1;
    public Vector3 vector = Vector3.forward;

	// Update is called once per frame
	void Update () {
        transform.Translate(vector * speed * direction * Time.deltaTime);	
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Target") {
            Debug.Log("Colliding with " + other.name);
            if (direction == 1) {
                direction = -1;
                Debug.Log("-1");
            } else {
                direction = 1;
                Debug.Log("1");

            }
        }
        if(other.tag == "Player") {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            other.transform.parent = null; 
        }
    }
}
