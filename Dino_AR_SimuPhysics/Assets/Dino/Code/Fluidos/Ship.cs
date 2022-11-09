using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    #region Variables

    

    [Header("Input")] 
    [SerializeField] private InputActionReference inputReferenceRotate;
    [SerializeField] private InputActionReference inputReferenceImpulse;
    [Header("Physics")]
    [SerializeField] private Transform _frontShip;
    [SerializeField] private Transform _backShip;
    [SerializeField] private float forceImpulse;
    [SerializeField] private float forceAngle = 10;
    [SerializeField] private Vector3 angleVelocity;

    private Rigidbody _rigidbody;
    private Keyboard _keyboard;
    private Vector2 _inputVector;
    private float _yVelocity;
    #endregion


    #region Methods unity
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _keyboard = Keyboard.current;

        inputReferenceRotate.action.performed += ctx => RotateShip();
        inputReferenceImpulse.action.performed += ctx => AddImpulseToShip();
    }

    void FixedUpdate()
    {
        
        ReadVectorValue();
        if (_keyboard.spaceKey.isPressed)
        {
            AddImpulseToShip();
        }

        // if (_keyboard.rKey.isPressed)
        // {
            // RotateShip();
        // }
        
    }
    #endregion

    #region Private Methods

    

    void AddImpulseToShip()
    {
        print("Add impulse");
        _rigidbody.AddForce(((-1)*_frontShip.forward) * forceImpulse, ForceMode.Force);
    }

    void RotateShip()
    {
        Quaternion deltaRotation = Quaternion.Euler(angleVelocity  * Time.fixedDeltaTime * forceAngle);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }
    
    
    void ReadVectorValue()
    {
        _inputVector = inputReferenceRotate.action.ReadValue<Vector2>();

        // print(_inputVector);
        
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
    #endregion


    #region Public Methods


    #endregion

}
