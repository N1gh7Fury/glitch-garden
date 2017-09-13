using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
	}

    private bool isTimeToSpawn(GameObject attackerPrefab)
    {
        Attacker attacker = attackerPrefab.gameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.spawnRate;
        float spawnPerSecond = 1 / meanSpawnDelay;
        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("spawn rate capped by framerate");
        }
        float threshold = spawnPerSecond * Time.deltaTime / 5;
        return (Random.value < threshold);
    }

    private void Spawn(GameObject attackerPrefab)
    {
        GameObject attacker = Instantiate(attackerPrefab) as GameObject;
        attacker.transform.parent = transform;
        attacker.transform.position = transform.position;
    }
}
