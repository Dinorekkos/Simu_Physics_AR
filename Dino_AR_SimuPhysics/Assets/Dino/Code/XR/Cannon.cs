using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cannon : MonoBehaviour
{

    [SerializeField] private HandHolder rightHandHolder;
    [SerializeField] private HandHolder leftHandHolder;
    
    
    bool _isGrabbingHolders = false;
    
    
    public bool IsGrabbingHolders
    {
        get { return _isGrabbingHolders; }
    }
    
    
    public Action<bool> OnGrabHolders;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void RotateCannon()
    {
        
    }
    
    private void HandleGrabHolders()
    {
        if (rightHandHolder.IsGrabbing && leftHandHolder.IsGrabbing)
        {
            _isGrabbingHolders = true;
        }
        else
        {
            _isGrabbingHolders = false;
        }
        
        OnGrabHolders?.Invoke(_isGrabbingHolders);

    }
    
    

}
