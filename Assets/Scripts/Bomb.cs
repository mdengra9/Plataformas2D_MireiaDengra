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
            SoundManager.instance.Boom();
            _animator.SetBool("Explosion", true);
            StartCoroutine("TiempoExplosion");
        }
    }

    IEnumerator TiempoExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Bomba fuera");
        Destroy(this.gameObject);
        SoundManager.instance.DeathSound();
    }
}
