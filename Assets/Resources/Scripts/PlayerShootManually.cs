using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class PlayerShootManually : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform weapon;
    bool canFire;
    private float timer;
    [SerializeField] float timeBetweenShooting;
    private void Start()
    {
        // get the main cam in the scene
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    private void Update()
    {
        //set vector to mousePos wtih World Points 
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //set rotation
        Vector3 rotation = mousePos - transform.position;
        ////get x Rotation for the weapon and transfer to degrees and subtract 90 as an offset(idk why it has a delay when following without offset :c)
        float rotationY = Mathf.Atan2(rotation.x, rotation.z) * Mathf.Rad2Deg - 90;
        //set the object rotation 
        transform.rotation = Quaternion.Euler(0, rotationY , 0);   
        //check if cant fire
        if (!canFire)
        {
            //if so start the timer
            timer += Time.deltaTime;
            //if timer reaches the limit
            if(timer > timeBetweenShooting)
            {
                //allow to fire and reset timer
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButtonDown(0) && canFire)
        {
            //if left mouse button pressed fire and disable firing bool
            canFire = false;
            Instantiate(bullet, weapon.transform.position, Quaternion.identity);
        }
    }
}
