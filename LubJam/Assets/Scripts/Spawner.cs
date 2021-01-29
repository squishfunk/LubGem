using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject item;

    private Vector3 respawnLocation;


	void Awake()
	{
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
	}

	// Start is called before the first frame update
	void Start()
    {
        item = (GameObject)Resources.Load("Item1", typeof(GameObject));

        respawnLocation = item.transform.position;

        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem()
	{
        int spawn = Random.Range(0, spawnLocations.Length);
        GameObject.Instantiate(item, spawnLocations[spawn].transform.position, Quaternion.identity);
	}
}
