using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableScript : MonoBehaviour
{
    public Transform ElectricDevice;
    public Transform Plug;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, ElectricDevice.position);
        lineRenderer.SetPosition(1, Plug.position);
    }
}
