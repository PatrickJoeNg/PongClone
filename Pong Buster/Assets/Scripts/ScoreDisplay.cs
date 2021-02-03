using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerOneScoreText;
    [SerializeField] TextMeshProUGUI playerTwoScoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        playerOneScoreText = GetComponent<TextMeshProUGUI>();
        playerTwoScoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        playerOneScoreText.text = gameSession.GetPlayerOneGoal().ToString();
        playerTwoScoreText.text = gameSession.GetPlayerTwoGoal().ToString();
    }
}
