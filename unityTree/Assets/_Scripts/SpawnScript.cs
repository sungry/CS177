using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject[] objs;
    public float spawnMin = 3f;
    public float spawnMax = 10f;

    private float gameTime;
	private float countTime;
	private float powerUpStart = 5f;
	private float playerKillerStart = 10f;
	private bool sleeping = true;	
	private GameObject self;

	// debugging coroutine
	private int count = 0;

	void Awake()
	{
		self = this.gameObject;

	}

	void Start ()
    {
		// begin tracking time to turn on spawners
		powerUpStart += Time.time;
		playerKillerStart += Time.time;
		gameTime = Time.time;

		Debug.Log ("Countdown begun...");

		StartCoroutine (StartSpawn ());
		
	}
	
    private void Update()
    {

		if (!sleeping) 
		{
//			spawnMin *= 0.75f;
//			spawnMax *= 0.7f;
			gameTime = Time.time;
		} 
    }

	IEnumerator StartSpawn()
	{
		count++;
		Debug.Log ("Checking if " + self.name + " ready to spawn #" + count);

		if (sleeping && powerUpStart < Time.time)
			enablePowerUps ();
		
		if (sleeping && playerKillerStart < Time.time)
			enableKillers ();

		yield return new WaitForSeconds (1.0f);

		if (sleeping)
			StartCoroutine (StartSpawn ());
		else
			Debug.Log (self.name + " is awake");

	}

    void Spawn()
    {
        Instantiate(objs[Random.Range(0, objs.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }

	/// send true to wake up, send false to put to sleep
	private void enablePowerUps()
	{
		Debug.Log ("Attemtping Enable at " + Time.time + " for " + self.name);

		if (self.name.StartsWith ("PowerUpSpawn")) 
		{
			Spawn ();
//			gameTime = Time.time;

			sleeping = false;
			Debug.Log ("Power up activated for " + self.name);
		} 
		else
			Debug.Log (self.name + " did not activate");

	}

	private void enableKillers()
	{
		if (self.name.StartsWith ("KillSpawner")) 
		{
			Spawn ();
//			gameTime = Time.time;

			sleeping = false;
			Debug.Log ("Killer activated for " + self.name);
		} 
		else
			Debug.Log (self.name + " did not activate");

	}

	/// returns true if script is sleeping
	public bool isSleeping()
	{
		return sleeping;
	}
}
