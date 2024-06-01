using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AgeDropDownRefresher : MonoBehaviour
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
        if (UserInfoSinglton.Instance.userData.userAge == UserAge.adult)
        {
            dropdown.value = 0;
        }
        else dropdown.value = 1;

    }
}
