using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public BoxCollider Backpack_col;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Item>() != null)
        {
            if (other.gameObject.GetComponent<Item>().IsRightObject) RightObjectInserted(other.gameObject);
            else WrongObjectInserted(other.gameObject);
        }
    }
    void RightObjectInserted(GameObject obj)
    {
        obj.SetActive(false);
    }
    void WrongObjectInserted(GameObject obj)
    {

    }
}
