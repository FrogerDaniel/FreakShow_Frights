using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] GameManager manager;
    private void OnCollisionEnter(Collision collision)
    {
        //if pick up collides with player add the number to the material amount and destroy pickup
        if(collision.gameObject.tag == "Player")
        {
            manager.ChangeMaterialAmount();
            Destroy(gameObject);
        }
    }
}
