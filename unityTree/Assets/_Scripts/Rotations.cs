using UnityEngine;
using System.Collections;

public class Rotations : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        transform.Translate((-0.8f) * Time.deltaTime, 0, 0, Camera.main.transform);
    }
}
