using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerRagdoll : MonoBehaviour
{
    public static AnimatorControllerRagdoll Instance;
    public Action OnCollisionDetects;

    public Animator myAnimator;

    public string ANIM_VARIABLE;
    public string ANIM_EVENT;
    public bool valueAnim;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        OnCollisionDetects += HandleAnimationTrue;
    }

    void Update()
    {
        
    }

    void HandleAnimationTrue()
    {
        print("Entra en collision?");
        myAnimator.SetBool(ANIM_VARIABLE, valueAnim);
    }

    void HandleAnimatorFalse()
    {
        myAnimator.SetBool(ANIM_VARIABLE, !valueAnim);

    }
}
