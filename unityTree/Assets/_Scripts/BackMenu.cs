using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackMenu : MonoBehaviour {

	public Button goBackButton;

	void Start() {
		goBackButton = goBackButton.GetComponent<Button> ();
	}

	public void Back() {
		Application.LoadLevel (0);
	}

}
