using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _moveSpeed = 0.1f;
    private Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddRelativeForce(new Vector3(_moveSpeed, 0 , _moveSpeed));
    }
}
