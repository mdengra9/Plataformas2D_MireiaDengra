using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la veolocidad de movimiento del personaje")]
    [SerializeField] private float _playerSpeed = 5;
    [Tooltip("Controla la fuerza de salto del personaje")]
    [SerializeField] private float _jumpForce = 5;
    private float _playerInputH;
    
    //private float _playerInputV;

    private Rigidbody2D _rBody2D;
    private GroundSensor _sensor;
    private Animator _animator;
    private SpriteRender _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
        if(Input.GetButtonDown("Jump") && _sensor._isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
       // _rBody2D.AddForce(new Vector2 (_playerInputH * _playerSpeed, 0), ForceMode2D.Impulse);

       _rBody2D.velocity = new Vector2(_playerInputH * _playerSpeed, _rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        _playerInputH = Input.GetAxis("Horizontal");

        if(_playerInputH != 0)
        {
            _animator.SetBool("IsRunning", true);
        }

        if(_playerInputH == 0)
        {
            _animator.SetBool("IsRunning", false);
        }

        if(Horizontal < 0)
        {
           _spriteRenderer.flipX = true;
        }

        else if(Horizontal > 0)
        {
            _spriteRenderer.flipX = false;
            //se ha de escribir igual que el parametro del animator el isRunning
        }

       /* _playerInputV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2 (_playerInputH, _playerInputV) *_playerSpeed * Time.deltaTime);*/
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("IsJumping", true);
    }
}
