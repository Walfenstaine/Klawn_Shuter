using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Data data;
    public float helse = 10;
    public AudioClip clip, damage, ded;
    public Animator anim;
    public ParticleSystem pS;
    public static Gun rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void OnDestroy()
    {
        rid = null;
    }

    public void Ded()
    {
        if (!anim.GetBool("Ded"))
        {
            Muwer muwer = Muwer.rid;
            muwer.enabled = false;
            anim.SetBool("Ded", true);
            SoundPlayer.regit.sorse.PlayOneShot(ded);
            helse = 0;
            Interface.rid.GameOver();
        }
    }
    public void Shut() {
        if (data.bulets > 0)
        {
            pS.Play();
            data.bulets -= 1;
            anim.SetBool("Shut", true);
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    hit.collider.GetComponent<EnemiAI>().Damage();
                }
            }
        }
        else
        {
            Interface.rid.NullBK();
        }
    }
    public void Damage()
    {
        if (helse > 1)
        {
            SoundPlayer.regit.sorse.PlayOneShot(damage);
            anim.SetBool("Damage", true);
            helse -= Random.Range(1,3);
        }
        else
        {
            Ded();
        }
    }
    public void Reload() {
        anim.SetBool("Shut", false);
        anim.SetBool("Damage", false);
    }
}
