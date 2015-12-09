using UnityEngine;
using System.Collections;

public class Translation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        transform.Translate((-1.2f)*Time.deltaTime, 0, 0, Camera.main.transform);
    }
}
