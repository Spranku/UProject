using System;
using UnityEngine;

public class InventoryComp : MonoBehaviour
{
    public byte CurrentScore => currentScore;
    private byte ScoresForKilling = 0;
    protected byte currentScore;

    public event Action<byte> OnScoreChanged;

    protected void Awake()
    {
        currentScore = 0;
    }

    public virtual void AddScore(byte NewScore)
    {
        currentScore += NewScore;
        int TotalScores = currentScore + ScoresForKilling;
        if (TotalScores > 255)
        {
            OnScoreChanged?.Invoke(255);
        }
        else
        {
            OnScoreChanged?.Invoke((byte)TotalScores);
        }
        OnScoreChanged?.Invoke((byte)TotalScores);
    }

    public virtual void AddScoresForKilling(byte NewScore)
    {
        ScoresForKilling += NewScore;
        int TotalScores  = currentScore + ScoresForKilling;
        if (TotalScores > 255)
        {
            OnScoreChanged?.Invoke(255);
        }
        else
        {
            OnScoreChanged?.Invoke((byte)TotalScores);
        }
    }

    public byte GetCurrentScore()
    {
        return currentScore;
    }

    public byte GetScoreForKilling()
    {
        return ScoresForKilling;
    }

    public int GetTotalScores()
    {
        return currentScore + ScoresForKilling;
    }
}
