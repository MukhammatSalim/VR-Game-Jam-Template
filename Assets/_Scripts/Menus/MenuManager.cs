using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [Header("Menus")]
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
    public UserData userdata;

    public void ChangeLangage(bool IsEng)
    {
        if (IsEng) UserInfoSinglton.Instance.userData.lang = AppLanguage.English;
        else UserInfoSinglton.Instance.userData.lang = AppLanguage.Russian;
    }

    public void ChangeMenuTo(GameObject NewMenu)
    {
        CurrentActiveMenu.SetActive(false);
        NewMenu.SetActive(true);

        CurrentActiveMenu = NewMenu;
    }

    public void ChangeAge(bool IsKid)
    {
        if (IsKid) UserInfoSinglton.Instance.userData.userAge = UserAge.kid;
        else UserInfoSinglton.Instance.userData.userAge = UserAge.adult;
    }


}
