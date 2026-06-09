using System;
using UnityEngine;

public class InventoryComp : MonoBehaviour
{
    public byte CurrentScore => currentScore;
    protected byte currentScore;

    public event Action<byte> OnScoreChanged;

    protected void Awake()
    {
        currentScore = 0;
    }

    public virtual void AddScore(byte NewScore)
    {
        currentScore += NewScore;
        OnScoreChanged?.Invoke(currentScore);
    }
}
