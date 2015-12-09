using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour 
{

	public GameObject[] tutorials;

	private GameObject tutorialText;
	private Vector3 tutPosition;

//	public PowerUpScript[] powerScript;

	private float goDelay = 1f;
	private float stopDelay = 5f;
	private float stageStart;
	private float stageEnd;
	private int tutorialStage = 0;
	
	// Use this for initialization
	void Start () 
	{
		stageStart = Time.time + goDelay;
		tutPosition = new Vector3 (110,125);

	}
	
	// Update is called once per frame
	void Update () 
	{

		// wait delay time, and execute stage 1: spawning the jump tutorial
		if (Time.time > stageStart && tutorialStage == 0) 
		{
			// create 1st tutorial text object
			tutorialText = (GameObject)Instantiate (tutorials[0], tutPosition, tutorials[0].transform.rotation);
			tutorialText.transform.SetParent(this.transform);

			tutorialStage++;

			stageEnd = Time.time + stopDelay;

			Debug.Log ("Spawned jump text");

		}

		// during stage 1, look for jump key press or 5 seconds
		if (tutorialStage == 1 && (Input.GetKeyDown(KeyCode.Space) || Time.time > stageEnd))
			tutorialStage++;

		// stage 2 == user has jumped, destroy text 1
		if (tutorialStage == 2 && Time.time > stageEnd)
		{
			Destroy(tutorialText);
			stageStart = Time.time + goDelay;

			tutorialStage++;

		}

 		// stage 3 == power up text
		if (tutorialStage == 3 && Time.time > stageStart) 
		{

			// create 2nd tutorial text object
			tutorialText = (GameObject)Instantiate (tutorials[1], tutPosition, tutorials[1].transform.rotation);
			tutorialText.transform.SetParent(this.transform);

			tutorialStage++;

			stageEnd = Time.time + stopDelay;


		}

		// stage 4, destroy 2nd tutorial text instance
		if (tutorialStage == 4 && Time.time > stageEnd) 
		{
			Destroy(tutorialText);

			tutorialStage++;
	
			stageStart = Time.time + goDelay;
		}

		// stage 5, start enemy tutorial text
		if (tutorialStage == 5 && Time.time > stageStart) 
		{
			Debug.Log("Spawning enemy text");

			tutorialText = (GameObject)Instantiate (tutorials[2], tutPosition, tutorials[2].transform.rotation);
			tutorialText.transform.SetParent(this.transform);

			tutorialStage++;

			stageEnd = Time.time + stopDelay;

		}

		if (tutorialStage == 6 && Time.time > stageEnd) 
		{
			Destroy (tutorialText);

			Debug.Log ("Tutorial completed");

			tutorialStage = 10;
		}
	}

	public int getStage()
	{
		return tutorialStage;
	}


}
