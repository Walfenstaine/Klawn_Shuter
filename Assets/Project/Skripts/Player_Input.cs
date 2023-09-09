using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour {

	private Muwer muwer;
	// Use this for initialization
	void Start () {
        muwer = Muwer.rid;
	}
    public void Shut()
    {
        Gun.rid.Shut();
    }

    void Update () {
        muwer.rut = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shut();
        }
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Tab))
        {
            Interface.rid.Menu();
        }
    }
}
