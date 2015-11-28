using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Button startButton;
    public Button options;

// Use this for initialization
    void Start () {
		Debug.Log ("en menu" + GameSystem.soundEnabled);
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
