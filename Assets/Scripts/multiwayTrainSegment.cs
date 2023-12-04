using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiwayTrainSegment : TrainSegment
{

    private int road = 0;
    private int loopsafe = 0;

    public GameObject point1;
    // Update is called once per frame

    private void Start() {
        //get the cildren of spriteRenderer
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
        //disable all sprites
        for(int i = 0; i < children.Length - 1; i++){
            children[i].enabled = false;
        }
        while(nextSegments[road] == null && loopsafe < 3){
            road = (road + 1) % 3;
            loopsafe++;
        } 
        loopsafe = 0;
        children[road].enabled = true;

        
    } 
    public override Vector3 Move(float interpolateAmount)
    {
        //get the cildren of gameobject
        Transform[] children = GetComponentsInChildren<Transform>();

        // Debug.Log(children.Length);
        //get the first child
        Transform firstChild = children[1];
        //get the last child
        Transform lastChild = children[2 + road];
        //interpolate the position of the moving part to the position of the last child
        return quadBezier(firstChild.transform.position, point1.transform.position, lastChild.position, interpolateAmount);
        // return Vector3.Lerp(firstChild.transform.position, lastChild.position, interpolateAmount);
    }

    Vector3 quadBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t){
        return (1-t)*(1-t)*p0 + 2*(1-t)*t*p1 + t*t*p2;
    }

    public void Switch(){
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
        
        children[road].enabled = false;
        road = (road + 1) % 3;
        while(nextSegments[road] == null && loopsafe < 3){
            road = (road + 1) % 3;
            loopsafe++;
        }
        loopsafe = 0;
        children[road].enabled = true;

    }

    public override GameObject getNextSegment(){
        // Debug.Log(nextSegments.Count);
        GameObject nextSegment = nextSegments[road];
        while(nextSegment == null && loopsafe < 3){
            nextSegment = nextSegments[road+1 % 3];
            loopsafe++;
        }
        loopsafe = 0;
        return nextSegment;
    }

    public override void OnDrawGizmos() {
        //get the cildren of gameobject
        Transform[] children = GetComponentsInChildren<Transform>();
        //get the first child
        Transform firstChild = children[1];
        //get the last child
        for(int i = 0; i < 3; i++){
            Transform lastChild = children[2 + i];
            for(float t = 0; t < 1; t+=0.02f)
            Gizmos.DrawLine(quadBezier(firstChild.transform.position,
                                        point1.transform.position,
                                        lastChild.position, t),
                            quadBezier(firstChild.transform.position,
                                        point1.transform.position,
                                        lastChild.position, t+0.02f));
        }
        
    }
}
