using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMotor : MonoBehaviour {

    public float heightOffset = 3.5f;
    public float behindOffset = 5.0f;
    public float smoothSpeed = 5.0f;
    public float swipeResistance = 200.0f;

    public Transform targetTrans;


    private Vector3 offset;
    private Vector3 desiredPosition;

    private Vector2 mouseDownPos;

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

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)  ){

            mouseDownPos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)){

            float mouseOffsetX = Input.mousePosition.x - mouseDownPos.x;

            if( Mathf.Abs( mouseOffsetX ) > swipeResistance ){

                if (mouseOffsetX > 0)
                    RotateOffsetVector(false);
                else
                    RotateOffsetVector(true);
            }
        }
        
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
