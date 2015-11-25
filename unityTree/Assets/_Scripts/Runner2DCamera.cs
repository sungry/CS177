using UnityEngine;
using System.Collections;

public class Runner2DCamera : MonoBehaviour {

    public Transform player;
	public int offset = 3;
	private AudioSource audioSource;

	void Start(){
        Debug.Log ("en game " + GameSystem.soundEnabled);

        if (GameSystem.soundEnabled == false) {
            audioSource = audioSource.GetComponent<AudioSource>();
            audioSource.mute = true;
        }
	}

	// Update is called once per frame
	void Update ()
    {
		transform.position = new Vector3(player.position.x + 6, offset, -10);
	
	}
}
