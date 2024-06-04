using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherController : MonoBehaviour
{
    public bool IsPinOut;
    bool ispinSoundWas = false;
    public AudioSource pinOutSound;
    public GameObject WaterPoint;
    public AudioSource Whoosh;
    public AudioClip WhooshClip;

    [SerializeField] private XRGrabInteractable _pinXR;
    [SerializeField] private Rigidbody _pinrb;
    public Collider PinPlace;

    private void Start()
    {
    }
    public void StartSpray(){
        if (IsPinOut){
            WaterPoint.SetActive(true);
            Whoosh.clip = WhooshClip;
            Whoosh.Play();
        }
    }

    public void StopSpray(){
        WaterPoint.SetActive(false);
        Whoosh.Stop();
    }

    public void RemovePin(){
        if (pinOutSound != null && ispinSoundWas == false) pinOutSound.Play();
        IsPinOut = true;
        ispinSoundWas = true;
        _pinXR.retainTransformParent = false;
        _pinrb.useGravity = true;
        _pinrb.isKinematic = false;
    }
    private void OnTriggerExit(Collider other) {
        RemovePin();
    }
}
