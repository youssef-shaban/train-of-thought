using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class GameOverHandler : MonoBehaviour
{
    public GameObject GameScoreText;
    public TextMeshProUGUI FinalScoreText;
    void Update()
    {
        // SwitchScene(true);
    }
    public void SwitchScene(bool show)
    {
        Transform parentTransform = transform;
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            GameScoreText.GetComponent<Canvas>().enabled = !show;
            Transform child = parentTransform.GetChild(i);
            if(child.GetComponent<Canvas>() != null)
                child.GetComponent<Canvas>().enabled=show;
            else if(child.GetComponent<SpriteRenderer>() != null)
                child.GetComponent<SpriteRenderer>().enabled = show;
        }
        if(show)
        {
            FinalScoreText.text ="YOUR SCORE \n" + ScoreManager.instance.score.ToString()+" / " +  ScoreManager.instance.NumberOfTrains.ToString();
        }
    }

}
