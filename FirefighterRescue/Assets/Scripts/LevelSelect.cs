using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;

    void Start()
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        level1Button.interactable = true;
        level2Button.interactable = unlocked >= 2;
        level3Button.interactable = unlocked >= 3;
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}