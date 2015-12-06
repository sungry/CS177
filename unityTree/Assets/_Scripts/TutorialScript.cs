using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour 
{
	public float startDelay;
	public float endDelay;
	public GameObject[] tutorials;
	
	private GameObject tutorialText;
	private Vector3 tutPosition;

	private float tutStart;
	private float tutEnd;
	private int tutorialStage = 0;

	// controll spawner activation
	private bool powerUps = false;
	private bool killerHeads = false;

	// Use this for initialization
	void Start () 
	{

		tutStart = Time.time + startDelay;
		tutPosition = new Vector3 (110,125);
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (Time.time >= tutStart && tutorialStage == 0) 
		{
			tutorialText = (GameObject)Instantiate (tutorials[0], tutPosition, tutorials[0].transform.rotation);
			tutorialText.transform.SetParent(this.transform);

			tutorialStage++;

			tutEnd = Time.time + endDelay;

			Debug.Log ("Spawned jump text");

		}

		// stage 1 == text appears
		if (tutorialStage == 1 && Input.GetKeyDown(KeyCode.Space))
			tutorialStage++;

		// stage 2 == user has jumped, destroy text 1
		if (tutorialStage == 2 && Time.time > tutEnd)
		{
			Destroy(tutorialText);

			tutorialStage++;

			tutStart = Time.time + startDelay;

		}

 		// stage 3 == display next tutorial text
		if (tutorialStage == 3 && Time.time > tutStart) 
		{
			Debug.Log ("Stage 3 ready");

			tutorialText = (GameObject)Instantiate (tutorials[1], tutPosition, tutorials[1].transform.rotation);
			tutorialText.transform.SetParent(this.transform);

			// start looking for power up to be collected
//			PowerUpScript collected = (PowerUpScript)GameObject.Find ("PowerUp").GetComponent<PowerUpScript>;

//			if (collected.isCollected)
			{
				tutorialStage++;

				//TextAsset newText = tutorialText.gameObject.GetComponent<TextAsset>;

				//newText.text = "JUMP";

				tutEnd = Time.time + endDelay;
			}

		}

		// stage 4, destroy 2nd tutorial text instance
		if (tutorialStage == 4 && Time.time > tutEnd) 
		{
			Destroy(tutorialText);

			tutorialStage++;
		}

		if (tutorialStage == 5) 
		{
			Debug.Log("Ready for stage 5");

			tutorialText = (GameObject)Instantiate (tutorials[2], tutPosition, tutorials[2].transform.rotation);
			tutorialText.transform.SetParent(this.transform);

		}
	}


}
