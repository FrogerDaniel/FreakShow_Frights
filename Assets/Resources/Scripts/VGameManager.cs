using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //var for "pick ups"
    public float materialAmount = 0f;


    public void ChangeMaterialAmount()
    {
        //change the amount of pick ups
        materialAmount += 5;
        Debug.Log(materialAmount);
    }

    // Start is called before the first frame update
    void Start()
    {
        //set the pick ups to zero to avoid stacking from previous sessions
        materialAmount = 0f;
        //make cursor visible for the gameplay
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
