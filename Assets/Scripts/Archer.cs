using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    Animator animationArcher;
    float cptrAnim;
    float tempsAnimation;

    [SerializeField] public GameObject fleche;
    private GameObject instanceDeFleche;
    private bool flecheIsRunning;
    private Vector3 positionSpawnFleche;
    private Vector3 rotationFleche;

    // Start is called before the first frame update
    void Start()
    {
        cptrAnim = 0;
        animationArcher = GetComponent<Animator>();
        tempsAnimation = animationArcher.GetCurrentAnimatorStateInfo(0).length - 2;
        flecheIsRunning = false;
        positionSpawnFleche = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 0.5f);
        rotationFleche = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        cptrAnim += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (tempsAnimation <= cptrAnim && flecheIsRunning == false)
        {
            flecheIsRunning = true;
            instanceDeFleche = Instantiate<GameObject>(fleche, positionSpawnFleche, Quaternion.LookRotation(rotationFleche));
            cptrAnim = 0;
            Debug.Log("Instance de fleche: " + instanceDeFleche);
        }
        if ( flecheIsRunning)
        {
            if(instanceDeFleche.transform.position.z <= 4.0f)
            {
                Destroy(instanceDeFleche);
                flecheIsRunning = false;
            }
            
        }
    }
}
