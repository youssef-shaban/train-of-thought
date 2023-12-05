using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGenerator : MonoBehaviour
{

    public GameObject ball;
    public List<Color> colors = new List<Color>();
    public int NumberOfBalls;
    private int counter =0;

    public GameObject starting;
    System.Random random = new System.Random();

    void Start()
    {

    InvokeRepeating("GenerateObject", 1f,1f);

    }
    void GenerateObject()
    {
        if(counter < NumberOfBalls)
        {
            var obj =Instantiate(ball,transform.position,Quaternion.identity);
            obj.GetComponent<trainMovement>().StartingSegment = starting;
            var rend = obj.GetComponent<SpriteRenderer>();
            rend.color=getColor();
            counter++;
        }
        

    }

    Color getColor()
    {
        int index = random.Next(0,colors.Count);
        return colors[index];
    }
    void Update()
    {
        
    }
}
