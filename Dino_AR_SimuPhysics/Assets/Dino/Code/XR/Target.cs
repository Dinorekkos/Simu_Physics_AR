using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private int _php = 100;
    private Collider _collider;
    private Rigidbody _rigidbody;
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;

    }

    void Update()
    {
        if (_php <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _php -= 20; 
            print("Live = " + _php);
        }
    }
}
