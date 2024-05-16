using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UserData", order = 2, fileName = "NewUserData")]
public class UserData : ScriptableObject
{
    public AppLanguage lang;
    public UserAge userAge;
}

public enum AppLanguage {
    English,
    Russian
}
public enum UserAge{
    kid,
    adult
}