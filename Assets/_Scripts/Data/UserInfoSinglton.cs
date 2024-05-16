using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoSinglton : MonoBehaviour
{
    public static UserInfoSinglton Instance;
    public UserData userData;
    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(this);

        DontDestroyOnLoad(this);
    }
}
