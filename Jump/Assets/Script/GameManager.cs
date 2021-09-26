using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;
    public GameObject spawnPoint;
    public AudioClip deadAudio;
    AudioSource audioSource;
    public AudioClip gemAudio;
    public AudioClip tapAudio;
    // Start is called before the first frame update
    int score = 0;
    int highScore;

    public Text scoreText;
    public Text highScoreText;
    public GameObject scoreManager;
    public GameObject menuGame;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score : " + highScore.ToString();
    }
    private void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButton(0))
            {
                StartGame();
            }
        }
    }
    public void StartGame()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(tapAudio);
        scoreManager.SetActive(true);
        gameStarted = true;
        spawnPoint.SetActive(true);
        StartCoroutine("IncreaseScore");
        menuGame.SetActive(false);
    }
    public void OverGame()
    {
        scoreManager.SetActive(false);
        gameStarted = false;
        Invoke("LoadScene", 1.2f);
        spawnPoint.SetActive(false);
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(deadAudio);
        StopCoroutine("IncreaseScore");
        SaveHighScore();   
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   IEnumerator IncreaseScore()
    {
        while(true){
            yield return new WaitForSeconds(1f);
            scoreText.text = score.ToString();
            score++;
            
        }
    }
    public void GemScore()
    {
        score += 4;
        audioSource.PlayOneShot(gemAudio);
    }
    public void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
