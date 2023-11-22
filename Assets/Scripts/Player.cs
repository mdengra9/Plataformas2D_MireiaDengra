using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

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
    //private GroundSensor _sensor;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayableDirector _director;

    //Score
    private int _score;
    public Text scoreText;


    public GameObject[] Hearts;
    private int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;

        _rBody2D = GetComponent<Rigidbody2D>();
       // _sensor = GetComponentInChildren<GroundSensor>();
       // _animator = GetComponentInChildren<Animator>();
        //_spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        Debug.Log(GameManager.instance.vidas);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
        }

        //Manera fácil salto
       /* if(GroundSemsor._isGrounded == true)
        {
            _animator.SetBool("IsJumping", false);
        }

        else
        {
            _animator.SetBool("IsJumping", true);
        }*/

        if(Input.GetButtonDown("Fire2"))
        {
            _director.Play();
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

        if(_playerInputH < 0)
        {
            transform.rotation = Quaternion.Euler (0,180,0);
            _animator.SetBool("IsRunning", true);
           //_spriteRenderer.flipX = true;
        }

        else if(_playerInputH > 0)
        {
            transform.rotation = Quaternion.Euler (0,0,0);
            _animator.SetBool("IsRunning", true);
            //_spriteRenderer.flipX = false;
            //se ha de escribir igual que el parametro del animator el isRunning
        }

        else
        {
            _animator.SetBool("IsRunning", false);
        }
       /* _playerInputV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2 (_playerInputH, _playerInputV) *_playerSpeed * Time.deltaTime);*/
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        
    }

    public void SignalTest()
    {
        Debug.Log("Señal recivida");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            GameManager.instance.GameOver();
            SoundManager.instance.DeathSound();
        }
        else if (collider.gameObject.layer == 8)
        {
            _score++;
            scoreText.text = _score.ToString();
        }
    }
}