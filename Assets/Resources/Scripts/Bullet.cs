using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //get the cam component
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        // get rb component
        rb = GetComponent<Rigidbody>();
        //set vector to the mouse position
        Vector3 screenMousePos = Input.mousePosition; 
        // apply z axis to it to get the same depth
        screenMousePos.z = transform.position.z; 
        //transform it to world space
        mousePos = mainCam.ScreenToWorldPoint(screenMousePos); 
        //set the direction of the bullet according to the mouse position
        Vector3 direction = (mousePos - transform.position).normalized;
        // set the velocity by multiplier
        rb.velocity = direction * bulletSpeed;

        //if needed to apply rotation uncomment this:

        //Vector3 rotation = transform.position - mousePos;
        //float rot = Mathf.Atan2 (rotation.z, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0,0,rot);
    }

}
