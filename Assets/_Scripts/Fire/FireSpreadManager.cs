using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireSpreadManager : MonoBehaviour
{
    public static FireSpreadManager Instance;
    public Transform Folder;
    public List<GameObject> Firespots = new List<GameObject>();
    public List<GameObject> CurrentActiveFlames = new List<GameObject>();
    public GameObject WinScreen;
    public TMP_Text FireCount;
    public TMP_Text FireCountRUS;
    private void Awake() {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Folder.childCount; i++) Firespots.Add(Folder.GetChild(i).gameObject);
    }
    private void Update() {

        if (Firespots.Count == 0) WinScreen.SetActive(true);
        FireCount.text = CurrentActiveFlames.Count.ToString();
        FireCountRUS.text = CurrentActiveFlames.Count.ToString();
    }
}
