using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public BoxCollider Backpack_col;
    public List<GameObject> RequiredItems = new List<GameObject>();
    int ItemAmountRequired;
    int CurrentAmount;
    public List<Toggle> toggles= new List<Toggle>();

    private void Awake() {
        ItemAmountRequired = RequiredItems.Count;
    }
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
        CheckoutObj(obj.GetComponent<Item>().ID);
        obj.SetActive(false);
        CurrentAmount += 1;
        if (CurrentAmount == ItemAmountRequired) {
            WinCondition();
        }
    }
    void WrongObjectInserted(GameObject obj)
    {

    }
    void WinCondition(){
        
    }
    void CheckoutObj(int ID){
        toggles[ID].isOn = true;
    }
}
