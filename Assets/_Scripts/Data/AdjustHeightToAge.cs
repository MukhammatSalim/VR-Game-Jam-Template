using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeightToAge : MonoBehaviour
{
    public UserData userdata;
    public float adultSize = 1.5f;
    private void Start()
    {
        
            if (userdata.userAge == UserAge.kid)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        
    }
}
