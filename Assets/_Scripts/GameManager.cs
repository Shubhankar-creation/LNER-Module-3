using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform rightAnchor;
    public GameObject controllers;

    public GameObject rayVisual;

    public GameObject Rope;
    private bool ropeOn;
    public GameObject pickExtUI;

    public AudioClip callRing;
    public AudioClip popUI;

    public bool canAlert;
    public bool alertPressed;

    [HideInInspector]
    public bool clothOn;

    public string dialedNumber;

    public bool pinRemoved;

    public GameObject particles;

    public int fireSize = 100;
    public float extinguisherSize;

    public float totalTime;
    public float alarmTime;
    public float phoneTime;
    public float maskTime;
    public float fireTime;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(!ropeOn && controllers.active)
        {
            ropeOn = true;
            pickExtUI.SetActive(true);
            Rope.SetActive(true);
        }

        if (pinRemoved && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.8f)
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RHand);

            if (!particles.GetComponent<AudioSource>().isPlaying)
                particles.GetComponent<AudioSource>().Play();
            else if(!particles.GetComponent<ParticleSystem>().isPlaying)
                particles.GetComponent<ParticleSystem>().Play();
        }
        else
        {

            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RHand);
            particles.GetComponent<AudioSource>().Stop();
            particles.GetComponent<ParticleSystem>().Stop();
        }
    }
}
