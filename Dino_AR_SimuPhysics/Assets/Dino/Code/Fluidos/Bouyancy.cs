using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bouyancy : MonoBehaviour
{
    [Header("Drag")] public float underWaterDrag = 4f;
    public float underWaterAngularDrag = 2f;
    public float airDrag = 0f;
    public float airAngularDrag = 0f;
    public float floatingForce = 12f;
    public float waterHeight = 0f;

    private Rigidbody _rigidbody;
    private bool _underWater;
    private bool isInWaterCube;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(!isInWaterCube) return;
        float deltaHeight = transform.position.y - waterHeight;
        if (deltaHeight < 0)
        {
            _rigidbody.AddForceAtPosition(Vector3.up * floatingForce * Mathf.Abs(deltaHeight), transform.position,
                ForceMode.Force);
            if (!_underWater)
            {
                _underWater = true;
                SwitchState(_underWater);
            }
        }
        else
        {
            if (_underWater)
            {
                _underWater = false;
                SwitchState(_underWater);
            }
        }
    }

    void SwitchState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            _rigidbody.drag = underWaterDrag;
            _rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            _rigidbody.drag = airDrag;
            _rigidbody.angularDrag = airAngularDrag;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Awa"))
        {
            waterHeight = other.transform.localScale.y;
            isInWaterCube = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Awa"))
        {
            waterHeight = 0;
            isInWaterCube = false;
            
        }
    }
}
