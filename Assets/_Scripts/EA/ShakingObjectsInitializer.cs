using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingObjectsInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] ShakingObjs = GameObject.FindGameObjectsWithTag("ShakingObject");
        foreach (GameObject obj in ShakingObjs){
            if (obj.GetComponent<ShakingObject>() == null)
            obj.AddComponent<ShakingObject>();
            obj.isStatic = false;
            obj.transform.parent.gameObject.isStatic = false;
        }
    }

}
