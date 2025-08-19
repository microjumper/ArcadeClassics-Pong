using System;
using Playfield;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void OnEnable()
    {
        GoalLine.OnGoalScored += HandleGoalScored;
    }

    private void OnDisable()
    {
        GoalLine.OnGoalScored -= HandleGoalScored;
    }

    private void HandleGoalScored(Side side)
    {
        switch (side)
        {
            case Side.Left:
                Debug.Log("Player Scored");
                break;
            case Side.Right:
                Debug.Log("AI Scored");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(side), side, null);
        }
    }
}