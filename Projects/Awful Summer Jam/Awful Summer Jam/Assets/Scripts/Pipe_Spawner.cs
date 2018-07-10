using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Spawner : MonoBehaviour {

    public GameObject[] pipePrefabs;
    private Transform playerTransform;
    private float spawnX = 1;
    private float safeZone = 10;
    private float distance = 5; // distance between pipes
    private float pipesOnScreen = 10;

    private List<GameObject> activePipes;

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activePipes = new List<GameObject>();

        for (int i = 0; i < pipesOnScreen; i++) // Spawn initial ammount of tiles 
        {
            if (i < 2)  // First 2 tiles are the empty ones 
                SpawnPipes();
            else
                SpawnPipes();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (playerTransform.position.x - safeZone > (spawnX - pipesOnScreen * distance)) 
        {
            SpawnPipes();
            DeletePipes();
        }
    }

    private void SpawnPipes()
    {
        //Spawn below pipe
        GameObject go;
        go = Instantiate(pipePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector2(0,-3.4f);
        go.transform.position += Vector3.right * spawnX;
        activePipes.Add(go);

        //Spawn above pipe
        GameObject go_inverse;
        go_inverse = Instantiate(pipePrefabs[1]) as GameObject;
        go_inverse.transform.SetParent(transform);
        go_inverse.transform.position = new Vector2(0, 3.4f);
        go_inverse.transform.position += Vector3.right * spawnX;
        activePipes.Add(go_inverse);

        spawnX += distance; //Calculate new spawnX
    }

    private void DeletePipes()
    {
        Destroy(activePipes[0]);
        activePipes.RemoveAt(0);
        Destroy(activePipes[0]);
        activePipes.RemoveAt(0);
    }
}
