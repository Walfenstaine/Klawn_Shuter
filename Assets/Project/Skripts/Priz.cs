using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Priz : MonoBehaviour
{
    public ParticleSystem ps;
    public Reward rew;
    public float speed;
    public bool detected;
    public GameObject balun, priz;
    private Rigidbody rb;
    private Vector3 startPose;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPose = transform.position;
    }
    public void Detect()
    {
        rb.drag = 0;
        detected = false;
    }
    void Reload()
    {
        rb.drag = 10;
        transform.position = startPose;
        detected = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!detected)
        {
            Instantiate(priz, transform.position, Quaternion.identity);
            Interface.rid.Menu();
            rew.ShowReward();
            Reload();
        }
        else
        {
            Reload();
            ps.Play();
        }
    }
    void Update()
    {
        balun.SetActive(detected);
    }
}
