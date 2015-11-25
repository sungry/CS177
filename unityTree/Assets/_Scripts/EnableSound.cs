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
            GameSystem.soundEnabled = true;
        }
        else {
            GameSystem.soundEnabled = false;
        }

		Debug.Log (GameSystem.soundEnabled);
    }
}
