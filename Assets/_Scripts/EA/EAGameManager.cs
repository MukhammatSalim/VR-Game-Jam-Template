using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EAGameManager : MonoBehaviour
{
    public List<GameObject> fallingobj;
    public GameObject FallingObjFolder;
    public int NumOfFallingObj;
    public float CD;
    public List<TMP_Text> timerText = new List<TMP_Text>();
    public List<GameObject> HandScreens = new List<GameObject>();
    public AudioSource EQSFX;

    private void Start()
    {
        Debug.Log("Falling objects in scene: " + FallingObjFolder.transform.childCount);
        for (int i = 0; i < FallingObjFolder.transform.childCount; i++)
        {
            fallingobj.Add(FallingObjFolder.transform.GetChild(i).gameObject);
        }

        
    }

    IEnumerator StartEQ()
    {
        for (int i = FallingObjFolder.transform.childCount; i > 0; i--)
        {
            dropCeiling();
            yield return new WaitForSeconds(CD);
        } //bext step
    }
    void dropCeiling()
    {
        Rigidbody currentCeiling = fallingobj[Random.Range(0, fallingobj.Count)].GetComponent<Rigidbody>();
        if (currentCeiling.GetComponent<Rigidbody>().constraints != RigidbodyConstraints.None)
        {
            currentCeiling.constraints = RigidbodyConstraints.None;
            currentCeiling.useGravity = true;
            Debug.Log("Ceiling has fallen");
        }
        else
        {
            currentCeiling = fallingobj[Random.Range(0, fallingobj.Count)].GetComponent<Rigidbody>();
            dropCeiling();
        }
    }
    public void StartTimer(int seconds)
    {
        StartCoroutine(Timer(seconds));
        StartCoroutine(StartEQ());
        HandScreens[0].SetActive(false);
        HandScreens[1].SetActive(true);
        EQSFX.Play();
    }
    public IEnumerator Timer(int seconds)
    {
        while (seconds > 0)
        {
            seconds -= 1;
            foreach (TMP_Text a in timerText) a.text = seconds.ToString();
            yield return new WaitForSeconds(1);
            
        }
        WIN();


    }
    public void WIN(){
        EQSFX.Stop();
        HandScreens[1].SetActive(false);
        HandScreens[2].SetActive(true);
    }
    public void GoAfterEA1(){
        if (UserInfoSinglton.Instance.userData.userAge == UserAge.adult)
         SceneTransitionManager.singleton.GoToScene(10);
         else SceneTransitionManager.singleton.GoToScene(0);
    }
}
