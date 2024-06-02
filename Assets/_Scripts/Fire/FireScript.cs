using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum FireType
{
    OrdinarySingle,
    OrdinarySpreading,
    Electical,
    Small
}
public class FireScript : MonoBehaviour
{

    [Header("Connections")]
    public GameObject CloseText;


    [Header("Particle system")]
    [SerializeField] new ParticleSystem particleSystem;
    public ParticleSystem NewParticleSys;
    [SerializeField] ParticleSystem.EmissionModule fireEmission;
    [Header("Extinguish")]
    [SerializeField] SphereCollider sphereCollider;
    float fadeRate = 1f;
    [SerializeField] float currentEmission;


    [Header("FireType")]
    public FireType fireType;

    [Header("Fire spread")]
    public float SpreadCD;
    public List<GameObject> SpreadFlames;

    [Header("Electric Fire")]
    public GameObject Plug;
    public bool IsSafeForWater;
    bool IsWronglyExtinguished;


    private void Start()
    {



        particleSystem = GetComponent<ParticleSystem>();
        fireEmission = particleSystem.emission;
        currentEmission = fireEmission.rateOverTime.constant;
        sphereCollider = GetComponent<SphereCollider>();
        if (fireType == FireType.OrdinarySpreading)
        {
            //StartCoroutine(StartSpreading());
        }
    }
    public void ExtinguishBy(GameObject other, string byWhat)
    {
        //gameObject.SetActive(false);
        if (currentEmission > 0)
        {
            if (other.tag == byWhat)
            {

                if (fireType == FireType.Electical) GameManager.Instance.ElectricalFireWin();
                // particleSystem.Stop();
                gameObject.gameObject.SetActive(false);
                currentEmission -= fadeRate;
                particleSystem.startSize = currentEmission;
                if (currentEmission <= 0)
                {

                }
            }
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided");
        switch (fireType)
        {
            case FireType.Small:
                {
                    ExtinguishBy(other, "Water");
                }
                break;
            case FireType.OrdinarySingle:
                {
                    ExtinguishBy(other, "Extinguisher");
                }
                break;
            case FireType.OrdinarySpreading:
                {
                    ExtinguishBy(other, "Extinguisher");
                }
                break;
            case FireType.Electical:
                {
                    if (other.tag == "Water")
                    {
                        if (IsSafeForWater)
                        {
                            ExtinguishBy(other, "Water");
                        }
                        else
                        {
                            if (IsWronglyExtinguished == false)
                            {
                                Debug.Log("Wrong tool");
                                CloseText.SetActive(true);
                                if (UserInfoSinglton.Instance.userData.lang == AppLanguage.Russian) CloseText.GetComponentInChildren<TMP_Text>().text = "Вы неправильно потушили пожар. Электроприбор нужно сначала выключить";
                                else CloseText.GetComponentInChildren<TMP_Text>().text = "This is wrong way to extinguish fire. You need to plug off the device";
                                particleSystem = gameObject.GetComponent<ParticleSystem>();
                                NewParticleSys.startSize = 3;
                                IsWronglyExtinguished = true;
                            }
                        }
                    }
                    if (other.tag == "Oil")
                    {
                        Debug.Log("Wrong tool");
                        CloseText.SetActive(true);
                         if (UserInfoSinglton.Instance.userData.lang == AppLanguage.Russian)  CloseText.GetComponentInChildren<TMP_Text>().text = "Вы неправильно потушили пожар. Масло не подходит для тушения";
                         else CloseText.GetComponentInChildren<TMP_Text>().text = "You can't extinguish device by oil";
                        particleSystem = gameObject.GetComponent<ParticleSystem>();
                        NewParticleSys.startSize = 3;
                        IsWronglyExtinguished = true;
                    }
                    if ((other.tag == "Extinguisher"))
                        ExtinguishBy(other, "Extinguisher");
                }
                break;
        }
    }
    public IEnumerator StartSpreading()
    {
        yield return new WaitForSeconds(SpreadCD);
        foreach (GameObject Flame in SpreadFlames)
        {
            Flame.SetActive(true);
        }
        yield return new WaitForSeconds(SpreadCD);
    }
}
