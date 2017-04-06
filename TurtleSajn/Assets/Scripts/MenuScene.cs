using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour {
    public Canvas MainCanvas;
    public Canvas OptionsCanvas;
    public GameObject audioSource;
    bool soundToggle = true;

    void Awake() {
        OptionsCanvas.enabled = false;
    }

    public void OptionsOn() {
        OptionsCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

    public void ReturnOn() {
        OptionsCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void LoadOn() {
        GameManager.changeScene(2);
        GameManager.unloadScene(1);
    }

    public void SoundOnOff() {
        soundToggle = !soundToggle;
        if(soundToggle) {
            audioSource.SetActive(true);
        } else {
            audioSource.SetActive(false);
        }
    }
    
    public void QuitOn() {
        Application.Quit();
    }
}
