
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour

{
    private Animator _animator;
    public static bool _isGrounded;

    void Awake() 
    {
        _animator = GameObject.Find("mage").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            _isGrounded = true;
            _animator.SetBool("IsJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            _isGrounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            _isGrounded = true;
        }
    }
}
