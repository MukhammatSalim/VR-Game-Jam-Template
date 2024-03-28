using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAGameManager : MonoBehaviour
{
    public List<GameObject> fallingobj;
    public GameObject FallingObjFolder;
    public int NumOfFallingObj;
    public float CD;
    private void Start()
    {
        Debug.Log("Детей в папке: " + FallingObjFolder.transform.childCount);
        for (int i = 0; i < FallingObjFolder.transform.childCount; i++)
        {
            fallingobj.Add(FallingObjFolder.transform.GetChild(i).gameObject);
        }

        StartCoroutine(StartEQ());
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
        } else
        {
            currentCeiling = fallingobj[Random.Range(0, fallingobj.Count)].GetComponent<Rigidbody>();
            dropCeiling();
        }
    }
}
