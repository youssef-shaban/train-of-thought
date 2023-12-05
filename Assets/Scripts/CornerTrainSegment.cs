using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerTrainSegment : TrainSegment
{

    public GameObject point1;
    // Update is called once per frame
    void Update()
    {
        
    }

    public override Vector3 Move(float interpolateAmount)
    {
   
        //get the cildren of gameobject
        Transform[] children = GetComponentsInChildren<Transform>();
        //get the first child
        Transform firstChild = children[1];
        //get the last child
        Transform lastChild = children[children.Length - 1];
        //interpolate the position of the moving part to the position of the last child
        return quadBezier(firstChild.transform.position, point1.transform.position, lastChild.position, interpolateAmount);
    }

    Vector3 quadBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t){
        return (1-t)*(1-t)*p0 + 2*(1-t)*t*p1 + t*t*p2;
    }

    

    public override void OnDrawGizmos(){
        //get the cildren of gameobject
        Transform[] children = GetComponentsInChildren<Transform>();
        //get the first child
        Transform firstChild = children[1];
        //get the last child    
        Transform lastChild = children[children.Length - 1];
        //draw a line between the first and last child
        for(float t = 0; t < 1; t+=0.02f)
            Gizmos.DrawLine(quadBezier(firstChild.transform.position,
                                        point1.transform.position,
                                        lastChild.position, t),
                            quadBezier(firstChild.transform.position,
                                        point1.transform.position,
                                        lastChild.position, t+0.02f));
    }
}
