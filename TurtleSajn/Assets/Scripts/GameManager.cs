using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
     GameObject gameManager;
     static UserInterface ui;
     static GameObject player;

    private void Awake() {
        gameManager = GameObject.FindWithTag("GameManager");
        ui = FindObjectOfType<UserInterface>();
        player = GameObject.FindWithTag("Player");
        PlayerPrefs.SetInt("score",0);
        changeScene(1);
    }
  
    internal static void changeScene(int index) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    internal static void unloadScene(int index) {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(index);
    }
    internal static bool isPointerOverGameObject() {
        return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }
    internal static void spawnPlayer(Transform transform) {
        player.transform.position = transform.position;
    }
    internal static void changeScore(string text) {
        ui.scoreText.text = text;
    }
  

}
