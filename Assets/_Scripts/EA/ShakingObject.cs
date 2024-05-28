using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingObject : MonoBehaviour
{
    Rigidbody rigidbody;
    bool StopShaking = false;
    float ShakingAplitute = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>() == null)
       rigidbody = gameObject.AddComponent<Rigidbody>();
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking(){
        while(!StopShaking){
            Debug.Log("Shaking" + Random.Range(0,5));
        rigidbody.AddForce(new Vector3(Random.Range(-ShakingAplitute,ShakingAplitute),Random.Range(-ShakingAplitute,ShakingAplitute),Random.Range(-ShakingAplitute,ShakingAplitute)) * 10);
        yield return new WaitForSeconds(0.2f);
        }
    }
}
