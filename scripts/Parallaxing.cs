using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;      // Array of all back and foregrounds for parallax
	private float[] autoScales;          // The proportion of movement for backgrounds based on z-axis
	public float smoothing = 1;          // Smoothing factor for parallax

	private Transform cam;               // Reference for main camera
	private Vector3 previousCamPosition;  // stores the previous frame camera location

	// Awake called before Start()
	void Awake () 
	{
		// set up reference for camera
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		// store previous frame
		previousCamPosition = cam.position;

		// assigning parallax scales based on z placement
		autoScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) 
		{
			autoScales[i] = -backgrounds[i].position.z;
		}


	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < backgrounds.Length; i++)
		{
			// parallax moves left & right opposed to camera
			float parallaxX = (previousCamPosition.x - cam.position.x) * autoScales[i];

			// store the target x position and update backgrounds
			float backgroundTargetPosX = backgrounds[i].position.x +parallaxX; 

			// parallax moves up & down opposed to camera
			float parallaxY = (previousCamPosition.y - cam.position.y) * autoScales[i];
			
			// store the target x position and update backgrounds
			float backgroundTargetPosY = backgrounds[i].position.y +parallaxY; 

			// update the background positions
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX,
			                                           backgroundTargetPosY,
			                                           backgrounds[i].position.z);

			// fade between the two positions using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position,backgroundTargetPos, 
			                                        smoothing * Time.deltaTime);
			
		}

		// update previous camera
		previousCamPosition = cam.position;
	}
}
