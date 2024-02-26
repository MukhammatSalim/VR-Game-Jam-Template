using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpreading : MonoBehaviour
{
    public GameObject FirePrefab;
    public int CD;
    Transform startpos;


    private void Start()
    {
        startpos = transform;
    }

    IEnumerator FireSpread()
    {

        yield return new WaitForSeconds(CD);
    }
}
