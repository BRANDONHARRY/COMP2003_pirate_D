using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText;
    public int playerScore;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerHealth.OnUpdateHealth += UpdateHealthBar;
        PlayerScore.OnUpdateScore += UpdateScore;
        PlayerSpeed.OnUpdateSpeed += UpdateSpeed;
    }

    private void OnDisable()
    {
        PlayerHealth.OnUpdateHealth -= UpdateHealthBar;
        PlayerScore.OnUpdateScore -= UpdateScore;
        PlayerSpeed.OnUpdateSpeed -= UpdateSpeed;
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        scoreText.text = "Score: " + playerScore.ToString();
        DataHandler.setScore(playerScore);
    }
    private void UpdateSpeed(string newSpeed)
    {
        //Debug.Log("Changing Speed to " + newSpeed);
        speedText.text = "Speed: " + newSpeed;
    }
}
