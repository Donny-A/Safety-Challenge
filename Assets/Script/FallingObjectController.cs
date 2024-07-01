using UnityEngine;
using UnityEngine.UI;

public class FallingObjectController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;
    private bool gameStarted = false;
    private float countdown = 3f; // Deklarasi countdown

    public Text countdownText;
    public Text resultText; // Teks untuk menampilkan hasil (Win/GameOver)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Set gravity scale to 0 initially
        countdownText.gameObject.SetActive(false); // Sembunyikan teks countdown
        resultText.gameObject.SetActive(false); // Sembunyikan teks hasil awalnya
    }

    void Update()
    {
        if (gameStarted && !isFalling)
        {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(countdown).ToString("0");

            if (countdown <= 0)
            {
                StartFalling();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Collision with: " + other.gameObject.name); // Debug log untuk memeriksa nama objek yang bersentuhan
    
    if (other.gameObject.name == "Player")
    {
        GameOver();
    }
    else if (other.gameObject.name == "Floor")
    {
        Win();
    }
}


    public void StartFalling()
    {
        isFalling = true;
        rb.gravityScale = 1; // Set gravity scale to 1 to start falling
        countdownText.gameObject.SetActive(false); // Sembunyikan teks countdown saat mulai jatuh
    }

    public void SetGameStarted(bool started)
    {
        gameStarted = started;
        countdownText.gameObject.SetActive(true); // Tampilkan teks countdown
        countdownText.text = "3"; // Set teks countdown awal
        countdown = 3f; // Reset countdown saat game dimulai
    }

    void Win()
    {
        resultText.text = "Win!";
        resultText.gameObject.SetActive(true);
        Time.timeScale = 0f; // Berhenti waktu (opsional)
        rb.velocity = Vector2.zero; // Berhenti objek jatuh
    }

    void GameOver()
    {
        resultText.text = "Game Over!";
        resultText.gameObject.SetActive(true);
        Time.timeScale = 0f; // Berhenti waktu (opsional)
        rb.velocity = Vector2.zero; // Berhenti objek jatuh
    }
}
