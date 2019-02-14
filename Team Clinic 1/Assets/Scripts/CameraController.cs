using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
    public float angleModX = 20;
    public float angleModY = 20;
    public float maxViewAngle = 4.5f;
    public float minViewAngle = 4.5f;

    private Vector3 offset;
    private float xPos;
    private float yPos;
    private float viewY;
    private float inputY;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position + offset;
        transform.Rotate(0, angleModX * Input.GetAxis("Mouse X"), 0, Space.World);
        //transform.RotateAround(point: player.transform.position, axis: Vector3.up, angle: angleModX * Input.GetAxis("Mouse X"));

        inputY = Input.GetAxis("Mouse Y");

        if (viewY >= maxViewAngle)
        {
            // We want to go backwards if true
            if(inputY < 0)
            {
                transform.Rotate(angleModY * inputY, 0, 0);
                //transform.RotateAround(point: player.transform.position, axis: transform.TransformVector(Vector3.left), angle: angleModY * inputY);
                viewY += inputY;
            }
        }
        if (viewY <= minViewAngle)
        {
            // We want to go upwards if true
            if (inputY > 0)
            {
                transform.Rotate(angleModY * inputY, 0, 0);
                //transform.RotateAround(point: player.transform.position, axis: transform.TransformVector(Vector3.left), angle: angleModY * inputY);
                viewY += inputY;
            }
        }
        if(viewY > minViewAngle && viewY < maxViewAngle)
        {
            transform.RotateAround(point: player.transform.position, axis: transform.TransformVector(Vector3.left), angle: angleModY * inputY);
            viewY += inputY;
        }
    }
    //transform.RotateAround(point: player.transform.position, axis: transform.TransformVector(Vector3.left), angle: angleModY * Input.GetAxis("Mouse Y"));
    void LateUpdate()
    {
        offset = transform.position - player.transform.position;
        //transform.LookAt(player.transform.position);
    }
}
