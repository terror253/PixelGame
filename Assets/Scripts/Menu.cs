using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject guideUI;

    private void Start()
    {
        menuUI.SetActive(true);
        guideUI.SetActive(false);
    }
    
    
    public void Playgame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quitgame()
    {
        Application.Quit();
    }

    public void viewGuide()
    {
        menuUI.SetActive(false);
        guideUI.SetActive(true);
    }    

    public void backToMenu()
    {
        menuUI.SetActive(true);
        guideUI.SetActive(false);
    }    
 
}