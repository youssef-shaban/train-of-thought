using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public int NumberOfTrains;

    public int score = 0;
    int travelled = 0;

private void Awake() {
            instance = this;
}

    void Start()
    { 
        score = 0;
        travelled = 0;
        scoreText.text ="Score: " +score.ToString()+" / " + NumberOfTrains.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text ="Score: " +score.ToString()+" / " + NumberOfTrains.ToString();
    }

    public int Travelled()
    {
        return travelled;
    }
    public void AddTravelled()
    {
        travelled +=1;
        return ;
    }
}
