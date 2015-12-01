using UnityEngine;
using System.Collections;

public class sceneChangeScript : MonoBehaviour {
	public void changeToScene(string input) {
        Application.LoadLevel(input);
	}
}
