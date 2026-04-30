using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI fireText;
    public TextMeshProUGUI messageText;

    public float timeLeft = 10f;
    public int totalFire = 2;
    public int currentFire = 0;
    float timer = 2f;

    public GameObject person;
    public GameObject truck;

    public Transform seatPoint;

    bool levelComplete = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (levelComplete) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "Time : " + Mathf.Ceil(timeLeft);

        fireText.text = "ดับไฟ: " + currentFire + "/" + totalFire;

        if (timeLeft <= 0)
        {
            RestartLevel();
        }

        if (currentFire >= totalFire)
        {
            StartCoroutine(FinishLevel());
            levelComplete = true;
        }
    }

    public void FireExtinguished()
    {
        currentFire++;
    }

    System.Collections.IEnumerator FinishLevel()
    {
        messageText.text = "Rescue Complete!";

        yield return new WaitForSeconds(1f);

        person.transform.position = seatPoint.position;
        person.transform.SetParent(truck.transform);

        yield return new WaitForSeconds(0.5f);

        while (timer > 0)
        {
            truck.transform.Translate(Vector2.right * 3f * Time.deltaTime);
            timer -= Time.deltaTime;
            yield return null;
        }

        NextLevel();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void PrevLevel()
    {
        int id = SceneManager.GetActiveScene().buildIndex;
        if (id > 1)
            SceneManager.LoadScene(id - 1);
    }

    public void NextLevel()
    {
        string current = SceneManager.GetActiveScene().name;

        if (current == "Level1")
        {
            PlayerPrefs.SetInt("UnlockedLevel", 2);
        }
        else if (current == "Level2")
        {
            PlayerPrefs.SetInt("UnlockedLevel", 3);
        }
        else if (current == "Level3")
        {
            SceneManager.LoadScene("WinScene");
            return;
        }

        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelSelect");
    }
}