using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [Header("Input")] 
    [SerializeField] private InputActionReference inputReference;
    [Header("Physics")]
    [SerializeField] private Transform _frontShip;
    [SerializeField] private float forceImpulse;
    [SerializeField] private float angleRotation;

    private Rigidbody _rigidbody;
    private Keyboard _keyboard;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _keyboard = Keyboard.current;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_keyboard.spaceKey.isPressed)
        {
            AddImpulseToShip();
        }
    }

    void AddImpulseToShip()
    {
        print("Add force");
        print(_frontShip.forward);
        _rigidbody.AddForce(((-1)*_frontShip.forward) * forceImpulse, ForceMode.Force);
    }
}
