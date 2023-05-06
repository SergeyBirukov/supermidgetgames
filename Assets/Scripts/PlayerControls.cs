using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public static PlayerControls Instance { get; private set; }
    [SerializeField] private float speed = 10;
    private Rigidbody2D _rigidbody2D;
    private Controls _controls;
    private Vector2 _moveInput;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        InputSystem.EnableDevice(Keyboard.current);
        _controls = new Controls();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
        
    private void FixedUpdate()
    {
        UpdateSpeed();
    }
        
    private void UpdateSpeed()
    {
        _moveInput = _controls.Player.Movement.ReadValue<Vector2>();
        _rigidbody2D.velocity = _moveInput * speed;
    }
    
    private void OnEnable()
    {
        _controls?.Enable();
    }

    private void OnDisable()
    {
        _controls?.Disable();
    }

    public Vector2 Velocity => _rigidbody2D.velocity;
}
