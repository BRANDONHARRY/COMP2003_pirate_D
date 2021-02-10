using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }

    public void InstructionsLoad()
    {
        SceneManager.LoadSceneAsync("Instructions", LoadSceneMode.Single);
    }

    public void BackToStart()
    {
        SceneManager.LoadSceneAsync("Start Menu", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        SceneManager.LoadSceneAsync("End Game", LoadSceneMode.Single);
    }
}
