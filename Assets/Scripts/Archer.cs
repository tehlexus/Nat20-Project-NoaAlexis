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
    private Quaternion rotationFleche;

    // Start is called before the first frame update
    void Start()
    {
        cptrAnim = 0;
        animationArcher = GetComponent<Animator>();
        tempsAnimation = animationArcher.GetCurrentAnimatorStateInfo(0).length;
        flecheIsRunning = false;
        positionSpawnFleche = new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z + 1f);
        rotationFleche = new Quaternion(0.6956865f, 0, -0.2705448f, 0.6654516f);
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
            instanceDeFleche = Instantiate<GameObject>(fleche, positionSpawnFleche, rotationFleche);
            cptrAnim = 0;
        }
        if ( flecheIsRunning)
        { 
            if (instanceDeFleche.transform.position.x >= 0f)
            {
                Destroy(instanceDeFleche);
                flecheIsRunning = false;
            }

        }
    }
}
