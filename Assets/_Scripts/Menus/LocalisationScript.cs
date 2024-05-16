using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationScript : MonoBehaviour
{
    public List<GameObject> Eng = new List<GameObject>();
    public List<GameObject> Rus = new List<GameObject>();

    public void Localise(){
        if (UserInfoSinglton.Instance.userData.lang == AppLanguage.English){
            foreach (GameObject go in Eng){
                go.SetActive(true);
            }
            foreach (GameObject go in Rus){
                go.SetActive(false);
            }
        }
        else 
        {
            foreach (GameObject go in Rus){
                go.SetActive(true);
            }
            foreach (GameObject go in Eng){
                go.SetActive(false);
            }
        }
    }
}
