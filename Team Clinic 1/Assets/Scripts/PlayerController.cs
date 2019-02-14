using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10;
    public float jumpForce = 5;
    public float angleMod = 20;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public GameObject moveTarget;

    private Rigidbody rb;
    private Vector3 startCoord;
    private bool isJumping;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startCoord = transform.position;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Move(moveHorizontal * Time.fixedDeltaTime, moveVertical * Time.fixedDeltaTime);

        //Fall Death/Respawn
        /*if (transform.position.y < -10)
        {
            transform.position = startCoord;
        }*/
    }

    void Move(float moveX, float moveZ)
    {
        Vector3 targetVelocity = new Vector3(moveX, 0.0f, moveZ);
        targetVelocity = moveTarget.transform.TransformVector(targetVelocity) * speed;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        //rb.AddForce(targetVelocity * speed);
    }
}
