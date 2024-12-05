using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
    }
}
