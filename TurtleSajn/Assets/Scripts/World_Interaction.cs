using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World_Interaction : MonoBehaviour {

    private int shrumCounter;

    private Text scoreText; 

    void Start() {
        shrumCounter = PlayerPrefs.GetInt("score");
        //scoreText = GameManager.getScoreText();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0) && !GameManager.isPointerOverGameObject()){
            GetInteraction();
        }    
    }

	void GetInteraction() {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)){
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable Object") {
                interactedObject.GetComponent<Interactable>().Interact();
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "shrum") {
            shrumCounter++;
            Destroy(collision.gameObject);
            GameManager.changeScore("Score " + shrumCounter);
        }
        if (collision.gameObject.tag == "fallPlat") {
            StartCoroutine(fall(collision));
        }
        if(collision.gameObject.tag == "Lava") {
            shrumCounter = 0;
            GameManager.changeScore("Score " + shrumCounter);
            GameManager.changeScene(2);
            GameManager.unloadScene(3);
        }
        if(collision.gameObject.tag == "CheckPoint") {
            PlayerPrefs.SetInt("score", shrumCounter);
            PlayerPrefs.Save();
            GameManager.changeScene(2);
            GameManager.unloadScene(3);
        }
    }

    private IEnumerator fall(Collision collision) {
        yield return new WaitForSecondsRealtime(2);
        collision.collider.attachedRigidbody.isKinematic = false;
        collision.collider.attachedRigidbody.useGravity = true;
    }

}