using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Orc : MonoBehaviour
{
    Animator animationOrc;
    float cptrAnim;
    float tempsAnimation;

    [SerializeField] public GameObject hit;
    private GameObject instancehit;
    private Transform orcTransform;
    private Vector3 positionSpawnhit;
    private Quaternion rotationSpawnhit;

    // Start is called before the first frame update
    void Start()
    {
        animationOrc = GetComponent<Animator>();
        cptrAnim = 0;
        tempsAnimation = animationOrc.GetCurrentAnimatorStateInfo(0).length;
        orcTransform = GetComponent<Transform>();
        positionSpawnhit = orcTransform.position;
        positionSpawnhit.x += 3;
        positionSpawnhit.y += 1;
        rotationSpawnhit = orcTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        cptrAnim += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (cptrAnim >= tempsAnimation)
        {
            cptrAnim = 0;
            instancehit = Instantiate(hit, positionSpawnhit, rotationSpawnhit);
        }
        Destroy(instancehit, 1);
    }
}
