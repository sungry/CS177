using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableSound : MonoBehaviour {

    public Toggle soundToggle;

    void Start() {

        soundToggle = soundToggle.GetComponent<Toggle> ();
    }

    public void SetMode(){
        if (soundToggle.isOn) {
			AudioListener.volume = 1.0f;
        }
        else {
			AudioListener.volume = 0.0f;
		}
    }
}
