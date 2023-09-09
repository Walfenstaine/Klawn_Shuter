using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouse : MonoBehaviour
{
    public bool onTouch;
    public float spector;
    private float tim;
    public void Ondrag()
    {
        onTouch = true;
    }
    public void OffDrag()
    {
        if (Time.time - tim < spector)
        {
            Shut();
        }
        onTouch = false;
    }
    public void Shut()
    {
        Gun.rid.Shut();
    }
    void Update()
    {
        if (onTouch)
        {
            Muwer.rid.rut = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        else
        {
            Muwer.rid.rut = Vector2.zero;
            tim = Time.time;
        }
    }
}
