using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        IncreaseSize,
        SuperBall,
        Laser
    }

    public PowerUpType powerUpType;
    [SerializeField] float speed = 5;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.position += Time.deltaTime * Vector3.down * speed;
    }
}
