using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayCoinSound();
            gameManager.addScore(1);
        }
        else if(collision.CompareTag("Trap"))
        {
            gameManager.gameover();
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.gameover();
        }
        else if (collision.CompareTag("Key") && gameManager.fullScore())
        {
            Destroy(collision.gameObject);
            gameManager.gamewin();
        }
    }
}
