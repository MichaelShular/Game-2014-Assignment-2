//Michael Shular 101273089
//GoalTrigger
//12/12/2021
//Summary: Controls goal state, whether the player has delayed the squirrel enough.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private GameStateController gameController;
    private bool winOrLose;
    [Header("Points/Win")]
    [SerializeField] float delayBeforWinAmount;
    [SerializeField] float delayBetweenBonusPoints;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameStateController>();
        StartCoroutine(timerBeforeWin());
        winOrLose = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Squirrel"))
        {
            if (winOrLose)
            {
                gameController.GetComponent<GameStateController>().endGame("You Win you delayed the squirrel \nBonus Points: " + gameController.getTotalPoints().ToString());
            }
            else
            {
                gameController.GetComponent<GameStateController>().endGame("You Lose squirrel arrived too early");
            }
           
        }
    }
    IEnumerator timerBeforeWin()
    {
        yield return new WaitForSeconds(delayBeforWinAmount);
        gameController.addedToTotalPoints(100);
        winOrLose = true;
        StartCoroutine(bonusPointsForExtraDelay());
    }  

    IEnumerator bonusPointsForExtraDelay()
    {
        yield return new WaitForSeconds(delayBetweenBonusPoints);
        gameController.addedToTotalPoints(20);
        StartCoroutine(bonusPointsForExtraDelay());
    }
 }
