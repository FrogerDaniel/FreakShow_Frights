using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    //store input actions on x y
    private Vector2 move;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
       
    }

    private void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        //uncomment if will apply rotation to the player
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }
}
