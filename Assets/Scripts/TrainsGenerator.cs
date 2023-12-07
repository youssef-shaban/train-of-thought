using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class ColorsAndClassestPair
{
    public int Class;
    public Color color;

    public ColorsAndClassestPair(int Class, Color color)
    {
        this.Class = Class;
        this.color = color;
    }
}

public class TrainsGenerator : MonoBehaviour
{

    public GameObject train;
    public GameObject GameOver;
    public List<ColorsAndClassestPair> ColorsAndClass = new List<ColorsAndClassestPair>();

    private int counter =0;

    public GameObject starting;
    System.Random random = new System.Random();

    void Start()
    {

    InvokeRepeating("GenerateObject", 0f,3f);

    }

    private void Update() {
        int TravelledTrains = ScoreManager.instance.Travelled();
        if(TravelledTrains == ScoreManager.instance.NumberOfTrains){
            GameOver.GetComponent<GameOverHandler>().SwitchScene(true);
        }

    }
    void GenerateObject()
    {
        if(counter < ScoreManager.instance.NumberOfTrains)
        {
            var obj =Instantiate(train,transform.position,Quaternion.identity);
            obj.GetComponent<trainMovement>().StartingSegment = starting;
            var colorClass = getColor();
            obj.GetComponent<ClassAssign>().ClassNumber = colorClass.Class;
            var rend = obj.GetComponent<SpriteRenderer>();
            rend.color=colorClass.color;
            counter++;
        }
        

    }

    ColorsAndClassestPair getColor()
    {
        int index = random.Next(0,ColorsAndClass.Count);
        return ColorsAndClass[index];
    }
}
