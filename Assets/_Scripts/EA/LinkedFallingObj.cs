using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedFallingObj : MonoBehaviour
{
    Rigidbody FallingObj;
    public Rigidbody ConnectedBody;
    private void Awake() {
        FallingObj = gameObject.GetComponent<Rigidbody>();
    }
    private void Update() {
        if(ConnectedBody.GetComponent<Rigidbody>().useGravity == true) FallingObj.useGravity = true;
    }
    public void Fall(){
        FallingObj.useGravity = true;
    }
}
