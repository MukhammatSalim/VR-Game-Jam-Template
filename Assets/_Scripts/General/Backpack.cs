 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public BoxCollider Backpack_col;
    public List<GameObject> RequiredItems = new List<GameObject>();
    int ItemAmountRequired;
    int CurrentAmount;
    public GameObject WrongObj;
    public List<Toggle> toggles= new List<Toggle>();
    public UnityEvent RightTodo;
    public UnityEvent WrongTodo;

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
    private void OnTriggerExit(Collider other) {
        WrongObj.SetActive(false);
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
        WrongObj.SetActive(true);
    }
    void WinCondition(){
        GameManager.Instance.Todo?.Invoke();
    }
    void CheckoutObj(int ID){
        toggles[ID].isOn = true;
        toggles[ID].transform.parent.GetChild(0).GetComponent<Image>().color = Color.green;
        toggles[ID].transform.parent.GetChild(1).GetComponent<Image>().color = Color.green;
    }
}
