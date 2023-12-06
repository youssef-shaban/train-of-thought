using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destenation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        var TrainClass = other.collider.GetComponent<ClassAssign>().ClassNumber; 
        if(gameObject.GetComponent<ClassAssign>().ClassNumber == TrainClass)
        {
            ScoreManager.instance.AddPoint();
            Destroy(other.collider);
        }
        ScoreManager.instance.AddTravelled();

         }
}
