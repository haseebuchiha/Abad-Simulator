using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;

    public GameObject gameOverText;

    public bool gameOver = false;

    public float scrollSpeed = -10.5f;

    private int score = 0;

    public Text scoreText;

    public AudioClip deathSound;

    public AudioClip normalSound;

    public AudioSource MusicSource;

	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        MusicSource.clip = normalSound;
        MusicSource.Play();
    }

   

    // Update is called once per frame
    void Update () {
        if (gameOver && Input.GetMouseButtonDown(0))//|| Input.touchCount > 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Year: " + score.ToString();
    }

    public void BirdDied()
    {
        MusicSource.Stop();
        MusicSource.clip = deathSound;
        MusicSource.Play();
        gameOverText.SetActive(true);
        gameOver = true;
    }

}
