using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainMovement : MonoBehaviour
{
    public GameObject StartingSegment;
    private float interpolateAmount;

    public float speed = 1f;
    
    private TrainSegment trainSegment;
    // Update is called once per frame
    void Update()
    { 
        trainSegment = StartingSegment.GetComponent<TrainSegment>();
        //get the trainSegment component of the starting segment
        interpolateAmount = (interpolateAmount + Time.deltaTime * speed);
        //move the train
        transform.position = trainSegment.Move(interpolateAmount);
        
        if(interpolateAmount >= 1)
        {
            //set the starting segment to the next segment
            try
            {
            StartingSegment = trainSegment.getNextSegment();
            //reset the interpolateAmount
            interpolateAmount = 0;
            }
            catch (System.Exception)
            {
                Destroy(gameObject);
            }

        }

    }
}
