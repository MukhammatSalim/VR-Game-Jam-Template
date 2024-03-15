using UnityEngine;

public class ProximityText : MonoBehaviour
{
    public GameObject text;
    public BoxCollider bcol;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject + " encountered");
        if (other.tag == "Player") {
            text.SetActive(true);
            Debug.Log(other.gameObject + "is player");
            } else Debug.Log(other.gameObject + "is not a player");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")text.SetActive(false);
    }
}
