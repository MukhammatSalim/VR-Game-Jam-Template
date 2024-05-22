using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeightToAge : MonoBehaviour
{
    public UserData userdata;
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.userData.userAge == UserAge.kid)
                transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            else transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else 
        {
            if (userdata.userAge == UserAge.kid)
                transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            else transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
