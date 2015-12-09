using UnityEngine;
using System.Collections;

public class DiagonalTranslation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        transform.Translate((-1.2f) * Time.deltaTime, (-1.2f) * Time.deltaTime, 0, Camera.main.transform);
    }
}
