using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour
{
    private Camera cameraPrincipale;
    void Start()
    {
        cameraPrincipale = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Update()
    {
        cameraPrincipale.transform.Rotate(0, 0.01f, 0);
    }
}
