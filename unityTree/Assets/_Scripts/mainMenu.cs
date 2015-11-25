using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public Button startButton;
	public Button options;

	// Use this for initialization
	void Start () {
		startButton = startButton.GetComponent<Button> ();
		options = options.GetComponent<Button> ();
	}
	
	public void StartLevel() {
		Application.LoadLevel (1);
	}

	public void StartOptions() {
		Application.LoadLevel (3);
	}
}
