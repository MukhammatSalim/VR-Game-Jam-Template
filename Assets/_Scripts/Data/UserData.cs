using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "UserData", order = 2, fileName = "NewUserData")]
public class UserData : ScriptableObject
{
    public AppLanguage lang;
    public UserAge userAge;

    void OnApplicationQuit()
    {
        lang = AppLanguage.none;
        userAge = UserAge.none;
    }
}

public enum AppLanguage {
    English,
    Russian,
    none
}
public enum UserAge{
    kid,
    adult,
    none
}