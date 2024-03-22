using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;
    void Start()
    {
        for(int i=0 ;i <16; i++){
            GameObject go = Instantiate(card, this.transform);

            float x = (i%4)*1.4f-2.1f;
            float y = (i/4)*1.4f-3.0f;
            go.transform.position = new Vector2(x,y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
