using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObjScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Player") {
            EAGameManager.instance.Lose();
        }
    }
}
