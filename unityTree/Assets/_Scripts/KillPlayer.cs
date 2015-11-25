using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

			Debug.Log (this.name + " killed " + other.name);

			Application.LoadLevel(1);
            return;
        }

    }
}