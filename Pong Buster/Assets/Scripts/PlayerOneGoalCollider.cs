using UnityEngine;

public class PlayerOneGoalCollider : MonoBehaviour
{
    [Header("Goal Audio")]
    [SerializeField] AudioClip goalSound;
    [SerializeField] [Range(0,1)] float goalSoundVolume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Calculate Ball value and add to goal count
        int ballValue = FindObjectOfType<Ball>().GetBallValue();
        FindObjectOfType<GameSession>().AddToPlayerOneGoal(ballValue);

        Debug.Log("Player One Score: " + FindObjectOfType<GameSession>().GetPlayerOneGoal());

        AudioSource.PlayClipAtPoint(goalSound, Camera.main.transform.position, goalSoundVolume);

        //Check for goal limit, if reached, end game
        FindObjectOfType<GameSession>().isGameFinished();

        //Reset game state
        FindObjectOfType<GameSession>().StartNewRound();
        FindObjectOfType<Ball>().ResetBallPos();
    }
}
