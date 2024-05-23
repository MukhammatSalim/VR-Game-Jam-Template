using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();

    }

    IEnumerator Shaking(){
        yield return null;
    }
}
