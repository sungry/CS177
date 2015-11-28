using UnityEngine;
using System.Collections;

public class JumpTutorial : MonoBehaviour 
{
	public float startDelay;
	public float endDelay;
	public GameObject tutorial1;
	public GameObject tutorial2;

	private GameObject jumpSpace;
	private Vector3 tutPosition;

	private float tutStart;
	private float tutEnd;

	private bool jumped = false;
	private bool text1 = false;
	private bool text2 = false;
	private bool text2Ready = false;

	// Use this for initialization
	void Start () 
	{
		tutStart = Time.time + startDelay;
		tutPosition = new Vector3 (110,125);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Time.time >= tutStart && !text1) 
		{
			jumpSpace = (GameObject)Instantiate (tutorial1, tutPosition, tutorial1.transform.rotation);
			jumpSpace.transform.SetParent(this.transform);

			text1 = true;

			tutEnd = Time.time + endDelay;

			Debug.Log ("Spawned jump text");

		}
		
		if (!jumped && text1 && Input.GetKeyDown(KeyCode.Space))
			jumped = true;

		if (jumped && Time.time > tutEnd)
		{
			Destroy(jumpSpace);
//			text2Ready = true;
//			tutStart = Time.time + startDelay;
//			Debug.Log ("Time" + Time.time + tutStart);
		}
/*
		if (!text2 && text2Ready && Time.time > tutStart) 
		{
			Debug.Log ("Text 2 ready");
			jumpSpace = (GameObject)Instantiate (tutorial2, tutPosition, tutorial2.transform.rotation);
			jumpSpace.transform.SetParent(this.transform);

			tutEnd = Time.time + endDelay;
			text2Ready = false;
			text2 = true;
		}

		if (text2 && Time.time > tutEnd) 
		{
			Destroy(jumpSpace);

		}
*/	}


}
