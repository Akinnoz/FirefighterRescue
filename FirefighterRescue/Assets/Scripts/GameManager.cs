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

        fireText.text = currentFire + "/" + totalFire;

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

        while (truck.transform.position.x < 15f)
        {
            truck.transform.Translate(Vector2.right * 3f * Time.deltaTime);
            yield return null;
        }

        NextLevel();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PrevLevel()
    {
        int id = SceneManager.GetActiveScene().buildIndex;
        if (id > 1)
            SceneManager.LoadScene(id - 1);
    }

    public void NextLevel()
    {
        int id = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(id + 1);
    }
}