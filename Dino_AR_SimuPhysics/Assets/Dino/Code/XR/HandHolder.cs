using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class HandHolder : XRBaseInteractable
{
    [Header("Hand Holder")]
    [SerializeField] private InputActionReference inputActionReferenceGrab;
    [SerializeField] private InputActionReference inputActionReferenceDrop;

    [SerializeField] HandController_xR handController;
    public Action<bool> OnGrabbed;
    private bool _isGrabbing;
    public bool IsGrabbing => _isGrabbing;

    protected override void Awake()
    {
        base.Awake();
        // onSelectEntered.AddListener(Grab);
        // onSelectExited.AddListener(Drop);
    }

    private void Start()
    {
        inputActionReferenceGrab.action.performed += ctx => Grab();
        inputActionReferenceDrop.action.performed += ctx => Drop();
        IXRSelectInteractor newInteractor = firstInteractorSelecting;
        List<IXRSelectInteractor> moreInteractors = interactorsSelecting;
    }

    public virtual void Grab()
    {
        Debug.Log("Se grabbea?");
        _isGrabbing = true;
        OnGrabbed?.Invoke(_isGrabbing);
        handController.HandleHandsVisible(false);
    }

    public virtual void Drop()
    {
        Debug.Log("Se suelta?");

        _isGrabbing = false;
        OnGrabbed?.Invoke(_isGrabbing);
        handController.HandleHandsVisible(true);

    }


    private void Update()
    {
        if (IsGrabbing)
        {
            transform.position = GetMidPoint(handController.transform.position, handController.transform.position);   
        }
    }
    
    private Vector3 GetMidPoint(Vector3 p1, Vector3 p2)
    {
        float p3X = (p1.x + p2.x) * .5f;
        float p3Y = (p1.y + p2.y) * .5f;
        float p3Z = (p1.z + p2.z) * .5f;
        Vector3 p3 = new Vector3(p3X, p3Y , p3Z);
        return p3;

    }

    
    
    
}
