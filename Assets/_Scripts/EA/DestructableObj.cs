using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObj : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Ceiling"){
            gameObject.SetActive(false);
        }
    }
}
