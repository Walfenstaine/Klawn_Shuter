using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemiAI : MonoBehaviour {
    public AudioClip udar, auch, ded;
    public Data data;
    public GameObject onDestroy;
    public GameObject[] loot;
	public float stopDist, helse = 10;
	public Animator anim;
	public Transform player;
	public NavMeshAgent agent;
    private bool damage;
    private void Start()
    {
        helse = Random.Range(1,3);
        player = Muwer.rid.transform;
    }
    public void OnKick()
    {
        var lokker = player.position - transform.position;
        lokker.y = 0;
        onDestroy.transform.rotation = Quaternion.LookRotation(lokker);
        if (player.GetComponentInChildren<Gun>())
        {
            if (Vector3.Distance(player.position, transform.position) <= stopDist)
            {
                player.GetComponentInChildren<Gun>().Damage();
            }
        }
        else
        {
            player = null;
        }
    }
    public void Damage()
    {
        if (helse > 1)
        {
            SoundPlayer.regit.sorse.PlayOneShot(auch);
            anim.SetBool("Damage", true);
            helse -= Random.Range(1, 3);
        }
        else
        {
            anim.SetBool("Ded", true);
        }
        damage = true;
        agent.isStopped = true;
    }
    public void Ded()
    {
        int num = Random.Range(0, loot.Length);
        Instantiate(loot[num], transform.position, Quaternion.identity);
        SoundPlayer.regit.sorse.PlayOneShot(ded);
        GameInterfase.rid.Kill();
        Destroy(onDestroy);
    }
    public void Resed()
    {
        damage = false;
        anim.SetBool("Damage", false);
        agent.isStopped = false;
    }

    void Update () {
        anim.SetFloat ("Speed", agent.velocity.magnitude/4);
        agent.speed = 1.5f + Muwer.rid.rut.magnitude*data.record;
        if (!damage)
        {
            if (player != null)
            {
                if (Vector3.Distance(player.position, transform.position) <= stopDist)
                {
                    agent.isStopped = true;
                    anim.SetBool("Kik", true);
                }
                else
                {
                    agent.isStopped = false;
                    anim.SetBool("Kik", false);
                }
                agent.destination = player.position;
            }
            else
            {
                agent.isStopped = true;
                anim.SetBool("Kik", false);
            }
        }
	}
}
