using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGameManager : MonoBehaviour
{
    [SerializeField] GameObject[] FireList;

    private void Start() {
        FireList = GameObject.FindGameObjectsWithTag("Flame");
    }
}
