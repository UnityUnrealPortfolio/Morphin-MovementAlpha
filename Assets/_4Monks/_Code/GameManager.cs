using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
           instance = this;
        }

        
    }
    public UnityEvent<int> OnScoreUpdate = new UnityEvent<int>();
    private int score;
    public int Score
    {
        get { return score; }
        set 
        {
            
            score = value;
            OnScoreUpdate.Invoke(score);
        }
    }
}
