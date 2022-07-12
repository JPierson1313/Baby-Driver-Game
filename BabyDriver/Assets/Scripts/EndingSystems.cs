using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSystems : MonoBehaviour
{
    [SerializeField] GameObject winScreenCanvas;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            winScreenCanvas.SetActive(true);
        }
    }
}
