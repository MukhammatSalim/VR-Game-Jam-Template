using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropDownRefresher : MonoBehaviour
{
    TMP_Dropdown dropdown;
    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        
    }
    private void OnEnable()
    {
        Refresh();
    }
    void Refresh()
    {
        Debug.Log("Refreshed");
        if (UserInfoSinglton.Instance.userData.lang == AppLanguage.English) 
        {
            dropdown.value = 1;
        }
        else dropdown.value = 0;

    }
}
