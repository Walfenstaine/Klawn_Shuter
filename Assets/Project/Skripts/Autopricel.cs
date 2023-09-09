using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autopricel : MonoBehaviour
{
    public Transform enemi;
    void Update()
    {
        Vector2 rut = Muwer.rid.rut;
        if (rut.magnitude > 0.1f)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    enemi = hit.collider.transform;
                }
                else
                {
                    enemi = null;
                }
            }
            else
            {
                enemi = null;
            }
        }
        else
        {
            if (enemi != null)
            {
                Vector3 nap = enemi.position - transform.position;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(nap),Time.deltaTime);

            }
        }
    }
}
