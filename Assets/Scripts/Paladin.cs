using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paladin : MonoBehaviour
{
    Animator animationPaladin;
    float cptrAnim;
    float tempsAnimation;

    [SerializeField] public GameObject slash;
    private GameObject instanceSlash;
    private Transform paladinTransform;
    private Vector3 positionSpawnSlash;
    private Quaternion rotationSpawnSlash;

    // Start is called before the first frame update
    void Start()
    {
        animationPaladin = GetComponent<Animator>();
        cptrAnim = 0;
        tempsAnimation = animationPaladin.GetCurrentAnimatorStateInfo(0).length;
        paladinTransform = GetComponent<Transform>();
        positionSpawnSlash = paladinTransform.position;
        rotationSpawnSlash = paladinTransform.rotation;
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
            instanceSlash = Instantiate(slash, positionSpawnSlash, rotationSpawnSlash);
        }
        Destroy(instanceSlash, 2);
    }
}
