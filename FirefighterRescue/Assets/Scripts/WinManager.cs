using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public void Credit()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
