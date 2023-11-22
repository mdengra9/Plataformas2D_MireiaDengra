using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 0)
        {
            Destroy(this.gameObject);
            SoundManager.instance.Star();
        }
    }
}
