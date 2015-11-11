using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject[] objs;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
	void Start ()
    {
        Spawn();
	}
	
    
    void Spawn()
    {
        Instantiate(objs[Random.Range(0, objs.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
