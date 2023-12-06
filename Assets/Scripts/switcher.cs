using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switcher : MonoBehaviour
{
    public GameObject trainSegment;

    // Update is called once per frame

    private void OnMouseUp() {
        trainSegment.GetComponent<multiwayTrainSegment>().Switch();
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
    }
    private void OnMouseOver() {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
    }
    private void OnMouseExit() {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.6f);
    }

    
}
