using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour {

    private Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private bool canZip = false;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (canZip == true && Input.GetKey("f")) {
            Zip();
        } 
        if(canZip == true && Input.GetKey("e")) {
            player.transform.position = endMarker.position;
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            canZip = false;
        }
	}

    void Zip() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        player.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }
    private void OnTriggerEnter(Collider other) {
       if(other.gameObject.tag == "Player") {
            canZip = !canZip;
            startTime = Time.time;
            startMarker = other.transform;
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.isKinematic = true;
        }
    }
}
