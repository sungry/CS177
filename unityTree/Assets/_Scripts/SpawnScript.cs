using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject[] objs;
    public float spawnMin = 3f;
    public float spawnMax = 10f;
    private float gameTime;
    void Start ()
    {
        Spawn();
        gameTime = Time.time;
	}

    private void Update()
    {
        if (Time.time > gameTime + 30f)
        {
            spawnMin *= 0.75f;
            spawnMax *= 0.7f;
            gameTime = Time.time;
        }

    }

    void Spawn()
    {
        Instantiate(objs[Random.Range(0, objs.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
