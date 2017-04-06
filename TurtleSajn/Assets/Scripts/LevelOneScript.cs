using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneScript : MonoBehaviour {
    public Transform spawnPoint;
	// Use this for initialization
	void Start () {
        GameManager.spawnPlayer(spawnPoint);
	}
	
	public void respawn() {
        GameManager.spawnPlayer(spawnPoint);
    }
}
