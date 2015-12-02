using UnityEngine;
using System.Collections;

public class Runner2DCamera : MonoBehaviour {

    public Transform player;
	public int offset = 3;

	// Update is called once per frame
	void Update ()
    {
		transform.position = new Vector3(player.position.x + 6, offset, -10);
	
	}
}
