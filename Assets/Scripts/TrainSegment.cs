using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSegment : MonoBehaviour
{
    public GameObject nextSegment;

    public virtual Vector3 Move(float interpolateAmount)
    {
   
        //get the cildren of gameobject
        Transform[] children = GetComponentsInChildren<Transform>();
        //get the first child
        Transform firstChild = children[1];
        //get the last child
        Transform lastChild = children[children.Length - 1];
        //interpolate the position of the moving part to the position of the last child
        return Vector3.Lerp(firstChild.transform.position, lastChild.position, interpolateAmount);
    }

    public virtual void OnDrawGizmos() {
        //get the cildren of gameobject
        Transform[] children = GetComponentsInChildren<Transform>();
        //get the first child
        Transform firstChild = children[1];
        //get the last child
        Transform lastChild = children[children.Length - 1];
        //draw a line between the first and last child
        Gizmos.DrawLine(firstChild.transform.position, lastChild.position);
    }
}
