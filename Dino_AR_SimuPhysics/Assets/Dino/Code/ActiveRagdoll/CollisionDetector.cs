using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hand")
        {
            AnimatorControllerRagdoll.Instance.OnCollisionDetects?.Invoke();
        }
    }
}
