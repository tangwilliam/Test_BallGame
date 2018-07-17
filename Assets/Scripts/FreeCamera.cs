using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour {

    public Joystick CameraJoystick;
    public Transform LookAt;

    public float sensivityX = 3.0f;
    public float sensivityY = 1.0f;
    public float distance = 4.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

	
	// Update is called once per frame
	void Update () {

        currentX += CameraJoystick.InputDirection.x * sensivityX;
        currentY += CameraJoystick.InputDirection.z * sensivityY;
	}

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = LookAt.position + rotation * dir;
        transform.LookAt(LookAt);
    }
}
