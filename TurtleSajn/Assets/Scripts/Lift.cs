using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    private bool pressButton = false;
    private bool isElevatorUp = false;
    
    public GameObject target;

    void OnMouseOver() {
        pressButton = true;
    }

    void OnMouseExit() {
        pressButton = false;
    }

    void OnMouseDown() {
        Animation anime = target.GetComponent<Animation>();

        if (!isElevatorUp) {
            anime.Play("elevator_up");
            isElevatorUp = true;
        } else {
            anime.Play("elevator_down");
            isElevatorUp = false;
        }
    }

    void OnGUI() {
        if(pressButton) {
            GUI.Box(new Rect(300, 300, 200, 20), "Press to use lift");
        }
    }
}
