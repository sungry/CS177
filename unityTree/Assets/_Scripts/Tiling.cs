using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	// offset for buddy loading
	public int offset = 2;

	// instantiation checks
	public bool hasRightBuddy = false;
	public bool hasLeftBuddy = false;

	// use for non-tile backgrounds
	public bool reverseScale = false;

	// width of the texture element
	private float spriteExtent;

	private Camera cam;
	private Transform myTransform;

	void Awake ()
	{
		cam = Camera.main;
		myTransform = transform;

	}

	// Use this for initialization
	void Start () {
		SpriteRenderer spriteRend = GetComponent<SpriteRenderer> ();
		spriteExtent = spriteRend.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!hasRightBuddy || !hasLeftBuddy) 
		{

			// calculate camera extent from player in game units
			float camExtent = cam.orthographicSize * Screen.width/Screen.height;

			// find edge of the ground visible by camera
			float edgeVisibleRight = myTransform.position.x + spriteExtent/2 - camExtent;
			float edgeVisisbleLeft = myTransform.position.x - spriteExtent/2 + camExtent;

			// check for edge of element to the right or left
			if (cam.transform.position.x >= edgeVisibleRight - offset &&
			    !hasRightBuddy)
			{
				MakeNewBuddy(1);
				hasRightBuddy = true;
			}
			else if (cam.transform.position.x <= edgeVisisbleLeft + offset &&
			         !hasLeftBuddy)
			{
				MakeNewBuddy(-1);
				hasLeftBuddy = true;
			}
		}
	}

	/// <summary>
	/// Makes the new buddy.
	/// </summary>
	/// <param name="direction">Direction.</param>
	void MakeNewBuddy (int direction)
	{
		// calculate position for the new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteExtent * direction, 
		                                   myTransform.position.y, myTransform.position.z);

		// instantiate new buddy
		Transform newBuddy = (Transform)Instantiate (myTransform, newPosition, myTransform.rotation);

		// makes buddy a mirror if the element doesn't tile
		if (reverseScale == true) 
		{
			newBuddy.localScale = new Vector3 (-newBuddy.localScale.x,
			                                   newBuddy.localScale.y,newBuddy.localScale.z);
		}

		newBuddy.parent = myTransform.parent;
		if (direction > 0) 
		{
			newBuddy.GetComponent<Tiling>().hasLeftBuddy = true;
		}
		else 
		{
			newBuddy.GetComponent<Tiling>().hasRightBuddy = true;
		}

	}
}
