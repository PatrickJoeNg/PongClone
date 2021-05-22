using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{

    [Header("Player Two Movement")]
    [SerializeField] float playerPaddleSpeed = 1f;
    [SerializeField] float padding = 1f;
    [SerializeField] float screenInHeight = 10f;

    //cached refs
    GameSession gameSesh;
    Ball currentBall;

    //config params
    float minY;
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        SetUpPaddleBoundaries();
        gameSesh = FindObjectOfType<GameSession>();
        currentBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            MovePaddle();
        }        
    }

    private void MovePaddle()
    {
        var deltaY = Input.GetAxis("P2_Vertical") * Time.deltaTime * playerPaddleSpeed;
        var newYPos = Mathf.Clamp(GetYPos() + deltaY, minY, maxY);

        transform.position = new Vector2(transform.position.x, newYPos);
    }


    private void SetUpPaddleBoundaries()
    {
        Camera gameCamera = Camera.main;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
    private float GetYPos()
    {
        if (gameSesh.IsAutoPlayEnabled())
        {
            return currentBall.transform.position.y;
        }
        else
        {
            return transform.position.y;
        }
    }

}
