using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed;

    public float MaxProximity;

    void Start()
    {

    }

    void Update()
    {
        var mov = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
        var rot = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;

        transform.Translate(0, mov, 0);
        transform.Rotate(0, 0, rot);
    }
}
