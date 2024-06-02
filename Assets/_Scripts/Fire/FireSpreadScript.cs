using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireSpreadScript : MonoBehaviour
{
    public float SpreadCD;

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("Enabled");
        StartCoroutine(SpreadFire());
        FireSpreadManager.Instance.CurrentActiveFlames.Add(gameObject);
    }
    private void OnDisable() {
        FireSpreadManager.Instance.CurrentActiveFlames.Remove(gameObject);
    }


    IEnumerator SpreadFire()
    {
        Debug.Log("StartSpread");
        yield return new WaitForSeconds(SpreadCD);
        Debug.Log("CD is off");

        for (int i = 0; i < UnityEngine.Random.Range(1, 2); i++) //Spread fire to random number of flames
        {
            float DistanceToClosestFire = 0;
            GameObject ClosestFire;
            ClosestFire = FireSpreadManager.Instance.Firespots[UnityEngine.Random.Range(0, FireSpreadManager.Instance.Firespots.Count)];
            foreach (GameObject frespot in FireSpreadManager.Instance.Firespots)
            {
                Debug.Log("Starting new spot");
                float Dist = Vector3.Distance(transform.position, frespot.transform.position);
                Debug.Log("Dist is: " + Dist);
                if (DistanceToClosestFire != 0)
                {
                    if (Dist < DistanceToClosestFire)
                    {
                        if (!gameObject.activeInHierarchy)
                        {
                            Debug.Log("New closest flame");
                            ClosestFire = frespot;
                            DistanceToClosestFire = Dist;
                        }

                    }
                    else
                    {
                        Debug.Log("New closest flame");
                        ClosestFire = frespot;
                        DistanceToClosestFire = Dist;
                    }

                }
                else Debug.Log("This fire is too far");


            }
            if (ClosestFire.activeSelf == false)
            {
                ClosestFire.SetActive(true);
                FireSpreadManager.Instance.Firespots.Remove(ClosestFire);
            }
        }

    }
}
