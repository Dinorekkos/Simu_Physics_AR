using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider[] collidersRagdoll;
    [SerializeField] private Rigidbody[] rigidsRagdoll;
    [SerializeField] private Collider mainCollider;
    [SerializeField] private Rigidbody mainRigidBody;


    public bool toogle;
    
    void Start()
    {
        
    }

    void Update()
    {
        Toggle(toogle);
    }


    void Toggle(bool value )
    {
        value = !toogle;

        animator.enabled = toogle;

        for (int i = 0; i < collidersRagdoll.Length; i++)
        {
            collidersRagdoll[i].enabled = value;
        }

        for (int i = 0; i < rigidsRagdoll.Length; i++)
        {
            rigidsRagdoll[i].isKinematic = !value;
        }

        if (value != toogle)
        {
            value = toogle;
            mainCollider.enabled = value;
            mainRigidBody.isKinematic = value;
        }
        

    }
    
    
    
}
