using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{

    Animator AnnimationMonstre;

    [SerializeField] public GameObject bouleDeFeu;
    private GameObject instanceBouleDeFeu;
    bool FireBallIsRunning;
    private Transform monsterTransform;
    private Vector3 positionSpawnBouleDeFeu;
    private Vector3 rotationBouleDeFeu;


    // Start is called before the first frame update
    void Start()
    {
        FireBallIsRunning = false;
        AnnimationMonstre = GetComponent<Animator>();
        monsterTransform = GameObject.Find("Monstre").GetComponent<Transform>();
        positionSpawnBouleDeFeu = new Vector3(monsterTransform.position.x, monsterTransform.position.y + 1, monsterTransform.position.z + 0.5f);
        rotationBouleDeFeu = new Vector3(0,90,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (0.3 < AnnimationMonstre.GetCurrentAnimatorStateInfo(0).normalizedTime && !FireBallIsRunning)
        {
            FireBallIsRunning = true;
            instanceBouleDeFeu = Instantiate<GameObject>(bouleDeFeu, positionSpawnBouleDeFeu, Quaternion.LookRotation(rotationBouleDeFeu));
            
        }
        if(instanceBouleDeFeu.transform.position.z >= 10f && FireBallIsRunning)
        {
            Destroy(instanceBouleDeFeu);
            Debug.Log("Test");
            FireBallIsRunning = false;
        }
        
    }
}