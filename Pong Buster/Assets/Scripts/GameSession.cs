using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Header("Game Init")]
    [SerializeField] int goalLimit = 10;
    [SerializeField] int playerOneGoal = 0;
    [SerializeField] int playerTwoGoal = 0;
    [SerializeField] GameObject ballPrefab;

    [Header("Autoplay Debug")]
    [SerializeField] bool isAutoPlayEnabled;

    //cached
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }
    private void Awake()
    {
        SetUpSingleton();
    }
    
    private void SetUpSingleton()
    {
        int numberGameSesh = FindObjectsOfType<GameSession>().Length;
        if (numberGameSesh >1)
        {
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetPlayerOneGoal()
    {
        return playerOneGoal;
    }
    public int GetPlayerTwoGoal()
    {
        return playerTwoGoal;
    }

    public void AddToPlayerOneGoal(int goalValue)
    {
        playerOneGoal += goalValue;
    }
    public void AddToPlayerTwoGoal(int goalValue)
    {
        playerTwoGoal += goalValue;
    }
    public int GetGoalLimit()
    {
        return goalLimit;
    }
    public void isGameFinished()
    {
        if (playerOneGoal >= goalLimit)
        {
            levelLoader.LoadGameOver();
        }
        else if (playerTwoGoal >= goalLimit)
        {
            levelLoader.LoadGameOver();
        }
    }
    public void StartNewRound()
    {
        //Instantiate(ballPrefab, new Vector2(0, 0), Quaternion.identity);

        FindObjectOfType<Ball>().StartNewRound();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
