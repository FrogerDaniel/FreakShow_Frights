using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] float bulletSpeed;
    [SerializeField] int damageAmount = 25;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        Vector3 screenMousePos = Input.mousePosition;
        screenMousePos.z = transform.position.z;
        mousePos = mainCam.ScreenToWorldPoint(screenMousePos);
        Vector3 direction = (mousePos - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
