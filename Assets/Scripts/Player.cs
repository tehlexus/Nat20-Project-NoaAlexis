using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    bool gameIsRunning;
    public bool playerIsGrounded;
    public bool playerIsJumping;
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

    private bool isPlayerReset;
    private float positionX;
    private float positionY;
    private float positionZ;

    AudioSource sourceAudio;

    void Start()
    {
        positionX = 1.46f;
        positionY = 10.03f;
        positionZ = -8.27f;

        isPlayerReset = false;

        rigidBody = GetComponent<Rigidbody>();
        gameIsRunning = false;
        playerIsJumping = false;
        playerIsGrounded = false;
        deplacementHorizontal = 0f;
        deplacementVertical = 0f;

        rotationX = 0f;
        speed = 150f;
        rotationSpeed = 200.0f;

        cameraPrincipale = GameObject.Find("Main Camera").GetComponent<Camera>();
        inversionY = GameManager.Instance.invertYAxis;
    }

    void Update()
    {
        inversionY = GameManager.Instance.invertYAxis;
        if (!gameIsRunning && rigidBody.velocity.y == 0)
        {
            gameIsRunning = true;
            playerIsGrounded = true;
        }

        if (playerIsGrounded && !playerIsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerIsJumping = true;
        }

        if (isPlayerReset)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(positionX, positionY, positionZ);
            sourceAudio = GetComponent<AudioSource>();
            sourceAudio.Play();

            GameManager.Instance.deathCmpt += 1;

            isPlayerReset = false;
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        switch(other.gameObject.name)
        {
            case "FireBall(Clone)":
            case "StonesHit(Clone)":
            case "MeteorsAttaque(Clone)":
            case "electroSlash(Clone)":
            case "Arrow(Clone)":
                isPlayerReset = true;
                break;
            default:
                break;
        }
    }
}
