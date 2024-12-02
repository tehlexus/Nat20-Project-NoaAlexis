using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Druide : MonoBehaviour
{
    Animator animationDruide;
    float cptrAnim;
    float tempsAnimation;

    [SerializeField] public GameObject Meteor;
    private GameObject instanceMeteor;
    private Transform paladinTransform;
    private Vector3 positionSpawnMeteor;
    private Quaternion rotationSpawnMeteor;

    // Start is called before the first frame update
    void Start()
    {
        animationDruide = GetComponent<Animator>();
        cptrAnim = 0;
        tempsAnimation = animationDruide.GetCurrentAnimatorStateInfo(0).length;
        paladinTransform = GetComponent<Transform>();
        positionSpawnMeteor = paladinTransform.position;
        positionSpawnMeteor.x += -5;
        positionSpawnMeteor.z += 8;
        positionSpawnMeteor.y += 0.05f;
        rotationSpawnMeteor = paladinTransform.rotation;
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
            instanceMeteor = Instantiate(Meteor, positionSpawnMeteor, rotationSpawnMeteor);
        }
        Destroy(instanceMeteor, 3);
    }
}
