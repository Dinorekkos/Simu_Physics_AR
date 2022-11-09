using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private CharacterController _player;
    void Start()
    {

        _player = this.gameObject.GetComponent<CharacterController>();
        // Debug.Log(_player); 
    }

    void Update()
    {
        
    }

    void Jump()
    {
        Vector2 jumpDirection = new Vector2(0, 1);
        float jumpForce = 2;
        
        _player.Move(jumpDirection * (Time.deltaTime * jumpForce));

    }
}
