using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementspeed;
    public float sensitivity = 10f;

    [SerializeField]
    private Vector2 turn;

    private bool turnactive = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            
            transform.position += (transform.forward * movementspeed);
        }
        if (Input.GetKey("s"))
        {
            transform.position += (transform.forward * -1.0f * movementspeed);
        }
        if (Input.GetKey("d"))
        {
            transform.position += (transform.right * movementspeed);
        }
        if (Input.GetKey("a"))
        {
            transform.position += (transform.right * -1.0f * movementspeed);
        }
        turnactive = Input.GetMouseButton(1);

        if (turnactive)
        {
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }  

    }
}
