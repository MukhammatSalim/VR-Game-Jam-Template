using UnityEngine;

public class ProximityText : MonoBehaviour
{
    public GameObject text;
    public BoxCollider bcol;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") text.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")text.SetActive(false);
    }
}
