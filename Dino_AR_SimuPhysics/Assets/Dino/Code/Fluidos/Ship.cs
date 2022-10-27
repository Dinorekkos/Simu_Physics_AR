using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [Header("Input")] 
    [SerializeField] private InputActionReference inputReference;
    [Header("Physics")]
    [SerializeField] private Transform _frontShip;
    [SerializeField] private Transform _backShip;
    [SerializeField] private float forceImpulse;
    [SerializeField] private Vector3 angleVelocity;

    private Rigidbody _rigidbody;
    private Keyboard _keyboard;
    private Vector2 _inputVector;
    private float _yVelocity;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _keyboard = Keyboard.current;

        inputReference.action.performed += ctx => RotateShip();

    }

    void FixedUpdate()
    {
        
        ReadVectorValue();
        // if (_keyboard.spaceKey.isPressed)
        // {
            // AddImpulseToShip();
        // }

        // if (_keyboard.rKey.isPressed)
        // {
            // RotateShip();
        // }
        
    }

    void AddImpulseToShip()
    {
        _rigidbody.AddForce(((-1)*_frontShip.forward) * forceImpulse, ForceMode.Force);
    }

    void RotateShip()
    {
        Quaternion deltaRotation = Quaternion.Euler(angleVelocity  * Time.fixedDeltaTime * forceImpulse);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }
    
    
    void ReadVectorValue()
    {
        _inputVector = inputReference.action.ReadValue<Vector2>();

        print(_inputVector);
        
        if (_inputVector.x < 0)
        {
            _yVelocity = 1;
            
        }
        else if(_inputVector.x > 0)
        {
            _yVelocity = -1;
        }
        
        angleVelocity = new Vector3(0, _yVelocity, 0);
    }
    
}
