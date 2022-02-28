using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteMenu;
    [SerializeField] GameObject ingameUI;

    private void Start()
    {
        levelCompleteMenu.SetActive(false);
        ingameUI.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ingameUI.SetActive(false);
            levelCompleteMenu.SetActive(true);
        }   
    }

    // Loading next scene/level and making the collected coins count 0.
    public void NextLevel()
    {
        Score.coinCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Loading main menu scene and making the collected coins count 0.
    public void MainMenu()
    {
        Score.coinCount = 0;
        SceneManager.LoadScene(0);
    }
}
