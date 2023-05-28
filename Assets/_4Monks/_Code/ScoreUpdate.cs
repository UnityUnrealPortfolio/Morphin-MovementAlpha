using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
   public void UpdateScore(int _score)
    {
        GetComponent<TMP_Text>().text = _score.ToString();
    }
}
