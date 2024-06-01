using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeLevelRestrictor : MonoBehaviour
{
    public List<GameObject> AdultLevels = new List<GameObject>();
    private void OnEnable() {
        if(UserInfoSinglton.Instance.userData.userAge == UserAge.kid){
            foreach(GameObject level in AdultLevels) {
                level.SetActive(false);
            }
        }
        else {
            foreach(GameObject level in AdultLevels) {
                level.SetActive(true);
            }
        }
    }
}
