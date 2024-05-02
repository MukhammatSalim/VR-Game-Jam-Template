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
    GameManager gameManager;
    public GameObject CloseText;

    [Header("Particle system")]
    [SerializeField] new ParticleSystem particleSystem;
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
            StartCoroutine(StartSpreading());
        }
    }
    public void ExtinguishBy(GameObject other, string byWhat)
    {
        if (currentEmission > 0)
        {
            if (other.tag == byWhat)
            {
                currentEmission -= fadeRate;
                fireEmission.rateOverTime = currentEmission;
                if (currentEmission <= 0)
                {
                    particleSystem.Stop();
                    sphereCollider.gameObject.SetActive(false);
                }
            }
        }
    }
    private void OnParticleCollision(GameObject other)
    {
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
                                CloseText.GetComponentInChildren<TMP_Text>().text = "Вы неправильно потушили пожар. Электроприбор нужно сначала выключить";
                                gameObject.transform.localScale *= 2f;
                                IsWronglyExtinguished = true;
                            }
                        }
                    }
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
