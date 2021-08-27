
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject[] powerUpsPrefabs;
    [SerializeField] byte powerUpPossibilityPrecentage = 10;

    private void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj == null)
        {
            Debug.Log("Objeto no encontrado");
        }
        else
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
            gameManager.BricksOnLevel++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (gameManager != null)
        {
            gameManager.BricksOnLevel--;
        }
        if (gameManager.bigSize == false && gameManager.SuperBall == false && gameManager.laser == false)
        {
            //Numero aleatorio entre 0 y 99
            int randomNumber = Random.Range(0, 100);
            if (randomNumber < powerUpPossibilityPrecentage)
            {
                //Crea un powerUp
                int randomPower = Random.Range(0, powerUpsPrefabs.Length);
                Instantiate(powerUpsPrefabs[randomPower], transform.position, Quaternion.identity);
            }
        }
        
        Destroy(gameObject);
    }
}
