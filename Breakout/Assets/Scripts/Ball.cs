using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;
    Vector2 moveDirecction;
    Vector2 currentVelocity;
    [SerializeField] float speed = 3;
    GameManager gameManager;
    [SerializeField] AudioClip paddleBounce;
    [SerializeField] AudioClip bounce;
    [SerializeField] AudioClip loseLive;
    [SerializeField] float yMinSpeed = 2;
    [SerializeField] TrailRenderer trail;
    AudioController audioController;


    public Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioController = FindObjectOfType<AudioController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Brick") && gameManager.SuperBall == true)
        {
            rigidbody2D.velocity = currentVelocity;
            return;
        }

        moveDirecction = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        if (gameManager.BallOnPlay)
        {
            //Si la velocidad actual en Y es menor que la velocidad minima
            if (Mathf.Abs(moveDirecction.y)< yMinSpeed)
            {
                moveDirecction.y = yMinSpeed * Mathf.Sign(moveDirecction.y);
            }
        }
        rigidbody2D.velocity = moveDirecction;

        if (collision.transform.CompareTag("DeathLimits"))
        {
            Debug.Log("Colision con el limite bajo");
            FindObjectOfType<AudioController>().PlaySfx(loseLive);
            if (gameManager != null)
            {
                gameManager.PlayerLives--;
            }
        }

        if (collision.transform.CompareTag("Player"))
        {
            FindObjectOfType<AudioController>().PlaySfx(paddleBounce);
        }

        if (collision.transform.CompareTag("Brick"))
        {
            FindObjectOfType<AudioController>().PlaySfx(bounce);
        }


    }

    public void ToggleTrail()
    {
        if (trail.enabled == true)
        {
            trail.enabled = false;
        }
        else
        {
            trail.enabled = true;
        }
    }
    public void LaunchBall()
    {
        transform.SetParent(null);
        rigidbody2D.velocity = Vector2.up * speed;
    }
    public void ResetBall()
    {
        Transform paddle = GameObject.Find("Paddle").transform;
        paddle.localScale = new Vector3(0.5f, 1f, 1f);
        rigidbody2D.velocity = Vector3.zero;
        transform.SetParent(paddle);
        Vector2 ballPosition = paddle.position;
        ballPosition.y += 0.5f;
        transform.position = ballPosition;
        gameManager.BallOnPlay = false;
    }
    void FixedUpdate()
    {
        currentVelocity = rigidbody2D.velocity;
    }
}
