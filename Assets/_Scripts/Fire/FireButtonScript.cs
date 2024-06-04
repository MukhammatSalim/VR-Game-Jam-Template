using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireButtonScript : MonoBehaviour
{
    public UnityEvent OnButtonPress;
    private void OnCollisionEnter(Collision other) {
        Debug.Log("TriggerEntered");
         OnButtonPress?.Invoke();
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("TriggerEntered");
        OnButtonPress?.Invoke();
    }
}
