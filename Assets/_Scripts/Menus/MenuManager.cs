using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [Header("Menus")]
    public GameObject StartingMenu;
    public GameObject AgeMenu;
    public GameObject Language;
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject About;
    public GameObject FireLvls;
    public GameObject EALvls;
    public GameObject GKlvls;
    [Header("Operations")]
    public GameObject CurrentActiveMenu;
    public bool IsFirstTime = true;

    private void Start()
    {
        if (IsFirstTime)
        {
            ChangeMenuTo(StartingMenu);
            IsFirstTime = false;
        }
        else ChangeMenuTo(MainMenu);


    }
    public void ChangeLangage(bool IsEng)
    {
        if (IsEng) UserInfoSinglton.Instance.userData.lang = AppLanguage.English;
        else UserInfoSinglton.Instance.userData.lang = AppLanguage.Russian;
        Debug.Log("Current Language: " + UserInfoSinglton.Instance.userData.lang);
    }

    public void ChangeMenuTo(GameObject NewMenu)
    {
        if(CurrentActiveMenu != null) CurrentActiveMenu.SetActive(false);
        NewMenu.SetActive(true);

        CurrentActiveMenu = NewMenu;
        Debug.Log("CurrentMenu: " + CurrentActiveMenu);
    }

    public void ChangeAge(bool IsKid)
    {
        if (IsKid) UserInfoSinglton.Instance.userData.userAge = UserAge.kid;
        else UserInfoSinglton.Instance.userData.userAge = UserAge.adult;
        Debug.Log("Current age: " + UserInfoSinglton.Instance.userData.userAge);
    }
    public void SwitchLanguage(TMP_Dropdown dropdown)
    {
        if (dropdown.value == 0) UserInfoSinglton.Instance.userData.lang = AppLanguage.Russian;
        else UserInfoSinglton.Instance.userData.lang = AppLanguage.English;
        Debug.Log("Current Language: " + UserInfoSinglton.Instance.userData.lang);
    }
    public void SwitchAge(TMP_Dropdown dropdown)
    {
        if (dropdown.value == 0) UserInfoSinglton.Instance.userData.userAge = UserAge.adult;
        else UserInfoSinglton.Instance.userData.userAge = UserAge.kid;
        Debug.Log("Current age: " + UserInfoSinglton.Instance.userData.userAge);
    }
    
    public void QuitApplication()
    {
        Application.Quit();
    }


}
