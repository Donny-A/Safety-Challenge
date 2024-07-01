using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartCountdown : MonoBehaviour
{
    public Text countdownText;
    public PlayerController playerController;
    public FallingObjectController fallingObjectController;

    private float countdown = 3f;
    private bool gameStarted = false;

    void Start()
    {
        countdownText.text = countdown.ToString("0");
    }

    void Update()
    {
        if (!gameStarted)
        {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(countdown).ToString("0");

            if (countdown <= 0)
            {
                StartCoroutine(StartGame());
            }
        }
    }

    private IEnumerator StartGame()
    {
        gameStarted = true;
        countdownText.text = "Start"; // Ubah teks menjadi "Start"
        yield return new WaitForSeconds(1f); // Jeda 1 detik
        countdownText.gameObject.SetActive(false);
        playerController.SetGameStarted(true);
        fallingObjectController.SetGameStarted(true); // Mengatur game dimulai di FallingObjectController
    }
}
