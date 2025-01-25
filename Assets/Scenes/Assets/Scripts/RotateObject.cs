using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Vector3 previous_mouse_position;
    public float rotation_speed = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previous_mouse_position = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 delta_mouse_position = Input.mousePosition - previous_mouse_position;

            float x_rotation = delta_mouse_position.y * rotation_speed * Time.deltaTime;
            float y_rotation = -delta_mouse_position.x * rotation_speed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(x_rotation, y_rotation, 0);
            transform.rotation = rotation * transform.rotation;

            previous_mouse_position = Input.mousePosition;
        }
    }
}
