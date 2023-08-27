using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnEmiter : MonoBehaviour
{
    public AudioClip emit;
    public GameObject enemy;
    public float interval;
    public ParticleSystem pS;
    private float timer;
    private bool active = true;
    private void Start()
    {
        timer = Time.time;
    }
    void Emit()
    {
        SoundPlayer.regit.sorse.PlayOneShot(emit);
        Instantiate(enemy, transform.position, Quaternion.identity);
        timer = Time.time;
        pS.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
        }
    }
    private void Update()
    {
        if (active)
        {
            if (Time.time > (timer + Random.Range(interval, interval * 2)))
            {
                Emit();
            }
        }
    }
}
