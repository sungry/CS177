using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	public GameObject scoreUp;
	public int scoreValue;
	
	protected bool selfDestruct = false;
	
	private bool inTutorial;

	private float destructCountdown = 1.0f;
	private float destructSequence;
	private float grow;
	private GameObject score;
    private AudioClip coffee;
    AudioSource audio;
	HUDScript hud;
//	TutorialScript tuts;

	void Start()
	{
		hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
        //		tuts = GameObject.Find ("Canvas Text").GetComponent<TutorialScript> ();
        audio = GetComponent<AudioSource>();
	}

    void OnTriggerEnter2D(Collider2D other)
    //void OnCollissionExit2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            hud.IncreaseScore(scoreValue);

			selfDestruct = true;
            audio.Play();
			destructSequence = Time.time;
			grow = this.transform.localScale.x * 0.1f;
 
        }
    }
	
	private void Update()
	{
		if (selfDestruct) 
		{

//			this.transform.localScale *= new Vector3(1.1, 1.1, 0);
			this.transform.localScale += new Vector3(grow, grow);

			if (Time.time > destructSequence + destructCountdown)
			{
				Destroy(this.gameObject);
				Debug.Log(this.name + " is dead");
			}

//			score.transform.localPosition += new Vector3(0f,0.1f);
//			Debug.Log (score.transform.localPosition.x + " x and " + score.transform.localPosition.y + " y");
		}

	}
	
	public int getScoreValue()
	{
		return scoreValue;
	}
}
