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
    float cptrAnim;
    float tempsAnimation;

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
        positionSpawnBouleDeFeu = new Vector3(monsterTransform.position.x, monsterTransform.position.y + 1, monsterTransform.position.z - 0.5f);
        rotationBouleDeFeu = new Vector3(monsterTransform.rotation.x, monsterTransform.rotation.y, monsterTransform.rotation.z);
        cptrAnim = 0;
        tempsAnimation = AnnimationMonstre.GetCurrentAnimatorStateInfo(0).length;
    }

    // Update is called once per frame
    void Update()
    {
        cptrAnim += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (tempsAnimation <= cptrAnim && FireBallIsRunning == false)
        {
            FireBallIsRunning = true;
            instanceBouleDeFeu = Instantiate<GameObject>(bouleDeFeu, positionSpawnBouleDeFeu, Quaternion.LookRotation(rotationBouleDeFeu));
            cptrAnim = 0;
        }
        if (FireBallIsRunning)
        {
            if(instanceBouleDeFeu.transform.position.z <= -5.0f)
            {
                Destroy(instanceBouleDeFeu);
                FireBallIsRunning = false;
            }
        }
    }
}