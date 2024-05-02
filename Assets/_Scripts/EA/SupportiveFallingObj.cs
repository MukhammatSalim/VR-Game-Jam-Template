using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportiveFallingObj : MonoBehaviour
{
    private void Awake()
    {
        if (gameObject.GetComponent<Rigidbody>() == null) { 
            gameObject.AddComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ceiling")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
