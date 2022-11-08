using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image[] imageLives;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = GameManager.Instance.playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
        if (lives != GameManager.Instance.playerLives)
        {
            SetLivesImages();
        }
    }

    private void SetLivesImages()
    {
        if (lives > 0)
        {
            lives--;
            imageLives[lives].gameObject.SetActive(false);
        }
    }
}
