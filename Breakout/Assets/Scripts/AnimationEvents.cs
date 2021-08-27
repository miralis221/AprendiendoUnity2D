using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

    [SerializeField] AudioClip explosion;

    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }

    public void SendExplosionSound()
    {
        FindObjectOfType<AudioController>().PlaySfx(explosion);
    }

}
