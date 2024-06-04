using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Events;

public enum GameState
{
    Fire,
    Earthquake
}
public class GameManager : MonoBehaviour
{
    [Header ("General")]
    public static GameManager Instance;
    public GameState CurrentGameState;
    public AudioSource audioSource;
    public UserData userData;
    
    private bool _next;
    [Header ("Fire")]
    public TextMeshProUGUI UpperText;
    public TextMeshProUGUI text;
    private int TotalNumberofFire = 0;
    int NumberofFire;
    public GameObject[] FireList;
    public GameObject WinScreenFire;
    public UnityEvent Todo;

   [Header ("GA")]
    public int Items;
    public GameObject WinScreenGA;
   


    private void Awake() {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        switch (CurrentGameState)
        {
            case GameState.Fire:
                {
                    foreach (GameObject fire in FireList)
                    {
                        TotalNumberofFire += 1;
                    }
                    for (int a = 0; a < TotalNumberofFire; a++)
                    {
                        FireList[a].GetComponent<ParticleSystem>().Play();
                    }
                    NumberofFire = 0;
                    text.text = NumberofFire + "/" + TotalNumberofFire;
                    break;
                }
        }
    }
    public void EndGameSequence()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        WinScreenFire.SetActive(true);

    }


    public void ChangeNumberOfFires()
    {
        NumberofFire += 1;
        text.text = NumberofFire + "/" + TotalNumberofFire;
        if (NumberofFire == TotalNumberofFire)
        {
            /*GameCompleted();*/
            WinScreenFire.SetActive(true);
        }
    }

    public void GameCompleted()
    {
        text.text = "";
        UpperText.text = "Весь огонь потушен!";
        /*EndGameSequence();*/

    }

    public void ChangeScene(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public int GetRandomFire()
    {
        int x = Random.Range(0, TotalNumberofFire);
        Debug.Log("Got New Fire");
        return x;
    }
    public void GoToLevelAfter2()
    {
        if (UserInfoSinglton.Instance.userData.userAge == UserAge.adult)
        {
            SceneTransitionManager.singleton.GoToScene(7);
        } else SceneTransitionManager.singleton.GoToScene(0);

    }
    public void ElectricalFireWin(){
        Todo?.Invoke();
        WinScreenFire.SetActive(true);

    }
    public void CheckNewItem(int amount){
        Items += amount;
        if (Items == 13) ShowWinScreen(WinScreenGA);
    }
    public void ShowWinScreen(GameObject WinScreen){
        WinScreen.SetActive(true);
    }

/*    IEnumerator Earthquake()
    {
        MainCameraShaker.Shake(1, 5, 3);
        yield return new WaitForSeconds(1);
    }*/

}
