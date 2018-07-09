using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMotor : MonoBehaviour {

    public float heightOffset = 3.5f;
    public float behindOffset = 5.0f;
    public float smoothSpeed = 5.0f;

    public Transform targetTrans;


    private Vector3 offset;
    private Vector3 desiredPosition;

    private void Start()
    {
        offset = new Vector3(0, heightOffset, -1 * behindOffset);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            RotateOffsetVector(true);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            RotateOffsetVector(false);
        
    }

    private void FixedUpdate()
    {
        desiredPosition = targetTrans.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(targetTrans.position + Vector3.up);

    }


    private void RotateOffsetVector( bool left )
    {
        float rotateSign;
        if (left)
            rotateSign = -1.0f;
        else
            rotateSign = 1.0f;

        offset = Quaternion.Euler(0, rotateSign * 90, 0) * offset;

    }

}
