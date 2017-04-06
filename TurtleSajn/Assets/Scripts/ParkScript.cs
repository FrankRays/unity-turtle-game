using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkScript : MonoBehaviour {
    public Transform spawnPoint;
 
    void Start () {
        GameManager.spawnPlayer(spawnPoint);
    }

}
