using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool gameIsRunning;
    bool playerIsGrounded;
    bool playerIsJumping;
    private float deplacementHorizontal;
    private float deplacementVertical;
    private Vector3 deplacementVector;

    private Rigidbody rigidBody;

    private float rotationX;
    private float rotationY;

    private Camera cameraPrincipale;

    private float speed;
    private float rotationSpeed;
    public bool inversionY;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameIsRunning = false;
        playerIsJumping = false;
        playerIsGrounded = false;
        deplacementHorizontal = 0f;
        deplacementVertical = 0f;

        rotationX = 0f;
        speed = 250f;
        rotationSpeed = 200.0f;

        cameraPrincipale = GameObject.Find("Main Camera").GetComponent<Camera>();
        inversionY = GameManager.Instance.invertYAxis;
    }

    void Update()
    {
        if (!gameIsRunning && rigidBody.velocity.y == 0)
        {
            gameIsRunning = true;
            playerIsGrounded = true;
        }

        if (playerIsGrounded && !playerIsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerIsJumping = true;
        }

        deplacementHorizontal = Input.GetAxis("Horizontal");
        deplacementVertical = Input.GetAxis("Vertical");


        deplacementVector = new Vector3(deplacementHorizontal, rigidBody.velocity.y, deplacementVertical);
        deplacementVector.x *= speed * Time.deltaTime;
        deplacementVector.z *= speed * Time.deltaTime;
        deplacementVector = transform.rotation * deplacementVector;
        if (gameIsRunning)
        {
            rotationY = Input.GetAxis("Mouse X");
            rotationX = Input.GetAxis("Mouse Y");

            if (!inversionY)
            {
                rotationX *= -1.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!playerIsGrounded && playerIsJumping && rigidBody.velocity.y == 0)
        {
            playerIsGrounded = true;
            playerIsJumping = false;
        }

        if (playerIsJumping && playerIsGrounded)
        {
            rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            playerIsGrounded = false;
        }

        rigidBody.velocity = new Vector3(deplacementVector.x, deplacementVector.y, deplacementVector.z);

        transform.Rotate(0, rotationY * rotationSpeed * Time.deltaTime, 0);
    }

    private void LateUpdate()
    {
        cameraPrincipale.transform.Rotate(rotationX * rotationSpeed / 2 * Time.deltaTime, 0, 0);
    }

    void invertYAxis()
    {
        inversionY = !inversionY;
    }
}
