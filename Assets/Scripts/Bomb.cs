using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 0)
        {
            GameManager.instance.GameOver();
            SoundManager.instance.DeathSound();
            _animator.SetBool("Explosion", true);
            StartCorutine(TiempoExplosion());
        }
    }

    IEnumerator TiempoExplosion()
    {
        yield return new WaitForSeconds(1f);
    }
}
