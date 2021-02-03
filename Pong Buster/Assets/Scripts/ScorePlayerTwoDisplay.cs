using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScorePlayerTwoDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetPlayerTwoGoal().ToString();
    }
}
