using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI deliveryScoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;

    public AudioSource audioSource;
    
    public int timer;
    public int framesPerSecond;
    int deliveryScore;
    int frameCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.Play(0);
        deliveryScore = 0;
        deliveryScoreText.text = "Total Deliveries Made: " + deliveryScore.ToString();

        frameCount = 0;
        timerText.text = "Time Left for Deliveries: " + timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        if (frameCount % 60 == 0 && Time.timeScale != 0f)
        {
            timer--;
        }

        timerText.text = "Time Left for Deliveries: " + timer.ToString();
        if (timer == 0f)
        {
            GameOver();
        }



        if (Time.timeScale == 0f && Keyboard.current.spaceKey.isPressed)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        audioSource.Play(0);
        gameOverText.gameObject.SetActive(true);

    }

    public void UpdateDeliveryScore()
    {
        deliveryScore++;
        deliveryScoreText.text = "Total Deliveries Made: " + deliveryScore.ToString();
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}