using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    Animator animationArcher;
    float cptrAnim;
    float tempsAnimation;

    [SerializeField] public GameObject Fleche;
    private GameObject instanceDeFleche;
    private bool flecheIsRunning;
    private Transform transformArcher;
    private Vector3 positionSpawnFleche;
    private Vector3 rotationFleche;

    // Start is called before the first frame update
    void Start()
    {
        cptrAnim = 0;
        tempsAnimation = animationArcher.GetCurrentAnimatorStateInfo(0).length;
        flecheIsRunning = false;
        transformArcher = transformArcher.parent;
        positionSpawnFleche = transformArcher.localPosition;
        rotationFleche = new Vector3(transformArcher.rotation.x, transformArcher.rotation.y, transformArcher.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        cptrAnim += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (tempsAnimation < cptrAnim && !flecheIsRunning)
        {
            flecheIsRunning = true;
            instanceDeFleche = Instantiate<GameObject>(Fleche, positionSpawnFleche, Quaternion.LookRotation(rotationFleche));
            cptrAnim = 0;
        }
        if (instanceDeFleche.transform.position.z <= 4.0f && flecheIsRunning)
        {
            Destroy(instanceDeFleche);
            flecheIsRunning = false;
        }
    }
}
