using UnityEngine;
using System.Collections;

public class Muwer : MonoBehaviour {
    public Vector2 rut;
    public float sensitivity = 1.1f;
	public Transform cam;
	public float minimumY = -60F;
	public float maximumY = 60F;
    public float minimumX = -60F;
    public float maximumX = 60F;

    private Vector3 moveDirection = Vector3.zero;
	float rotationY = 0F;
    float rotationX = 0F;
    public float spid { get; set; }
	public static Muwer rid {get; set;}

	void Awake(){
		if (rid == null) {
			rid = this;
		} else {
			Destroy (this);
		}
	}
	void OnDestroy(){
		rid = null;
	}

	void Update() {
        if (rut.magnitude > 0.1f)
        {
            rotationY += rut.y * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            rotationX += rut.x * sensitivity;
            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
            cam.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else
        {
            return;
        }
    }
}
