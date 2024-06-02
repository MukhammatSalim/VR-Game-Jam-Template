using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSocketScript : MonoBehaviour
{
    public GameObject Plug;
    public FireScript connectedFire;
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Thing exitted: " + other);
        if(other.name == "Plug")
        {
            connectedFire.IsSafeForWater = true;
            Debug.Log("Fire is safe to extinguish");
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
