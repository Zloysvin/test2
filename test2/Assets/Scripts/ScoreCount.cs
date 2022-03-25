using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public int score = 0;
    private int OldScore = 0;
    public GameObject ScoreText;
    private void FixedUpdate()
    {
        if (score != OldScore)
        {
            ScoreText.GetComponent<Text>().text = score.ToString();
            OldScore = score;
        }
    }
}
