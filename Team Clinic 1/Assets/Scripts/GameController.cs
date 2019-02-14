using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnEnemies()
    {
        foreach(GameObject spawnPoint in spawnPoints)
        {
            Instantiate(enemy, spawnPoint.transform);
        }
    }
}
