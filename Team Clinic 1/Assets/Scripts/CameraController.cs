using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
    public float angleModX = 20;
    public float angleModY = 20;
    public float maxViewAngle = 5f;
    public float minViewAngle = 5f;

    private Vector3 offset;
    private float xPos;
    private float yPos;
    private float viewY;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position + offset;
        transform.RotateAround(point: player.transform.position, axis: Vector3.up, angle: angleModX * Input.GetAxis("Mouse X"));
        
        viewY += Input.GetAxis("Mouse Y");
        if(viewY <= maxViewAngle || viewY >= minViewAngle)
        {
            if(viewY == maxViewAngle && Input.GetAxis("Mouse Y") < 0)
            {
                transform.RotateAround(point: player.transform.position, axis: transform.TransformVector(Vector3.left), angle: angleModY * Input.GetAxis("Mouse Y"));
            }

            else if (viewY == minViewAngle && Input.GetAxis("Mouse Y") > 0)
            {
                transform.RotateAround(point: player.transform.position, axis: transform.TransformVector(Vector3.left), angle: angleModY * Input.GetAxis("Mouse Y"));
            }
            else
            {
                transform.RotateAround(point: player.transform.position, axis: transform.TransformVector(Vector3.left), angle: angleModY * Input.GetAxis("Mouse Y"));
            }
        }
    }
    
    void LateUpdate()
    {
        offset = transform.position - player.transform.position;
        //transform.LookAt(player.transform.position);
    }
}
