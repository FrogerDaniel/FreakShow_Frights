using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float materialAmount = 0f;


    public void ChangeMaterialAmount()
    {
        materialAmount += 5;
        Debug.Log(materialAmount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
