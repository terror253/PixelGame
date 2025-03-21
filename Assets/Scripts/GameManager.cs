using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private GameObject gamewinUI;

    private AudioManager audioManager;

    private bool isGameOver = false;
    private bool isGameWin = false;
    private bool isCoinFull = false;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Start()
    {
        updateScore();
        gameoverUI.SetActive(false);
        gamewinUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int points)
    {
        score += points;
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void gameover()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameoverUI.SetActive(true);
        audioManager.StopBackGroundMusic();
    }

    public void ReStartGame()
    {
        isGameOver = false;
        score = 0;
        updateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void gamewin()
    {
        isGameWin = true;
        gamewinUI.SetActive(true);
        Time.timeScale = 0;
        audioManager.StopBackGroundMusic();
    }

    public bool IsGameWin()
    {
        return isGameWin;
    }

    public bool fullScore()
    {
        if(score==20)
        {
            isCoinFull = true;
        }
        else
        {
            isCoinFull = false;
        }
        return isCoinFull;
    }    
}
