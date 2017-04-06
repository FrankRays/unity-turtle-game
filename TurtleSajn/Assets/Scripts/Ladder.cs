using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private bool inside = false;
    private float heightFactor = 3.8f;

    private My_Player_Controller thirdPUC;
	// Use this for initialization
	void Start () {
        thirdPUC = GetComponent<My_Player_Controller>();
	}

   private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ladder") {
            Debug.Log("Interacting with ladder");
            thirdPUC.enabled = false;
            inside = !inside;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Ladder") {
            thirdPUC.enabled = true;
            inside = !inside;
        }
    }
    // Update is called once per frame
    void Update () {
        if(inside == true && Input.GetKey("w"))
            this.transform.position += Vector3.up / heightFactor;
	}
}
