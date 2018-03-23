using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject Top;
    public GameObject Bottom;

    public float ChargeSpeed;
    public float MaxAngle;
    public float RotationSpeed;

    void Start()
    {

    }

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
     //  //Aiming
     //  var h = Input.GetAxis("Vertical") * Time.deltaTime * RotationSpeed;
     //  var v = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;
	 //
     //  transform.Rotate(0, 0, h);
     //  transform.Rotate(v, 0, 0);
	 //
     //  Debug.Log("X: " + transform.rotation.eulerAngles.x);
     //  Debug.Log("Z: " + transform.rotation.eulerAngles.z);
	 //
     //  //Maximum angle
     //  if (transform.rotation.eulerAngles.x > MaxAngle && transform.rotation.eulerAngles.x < (360 - MaxAngle))
     //  {
     //      if (transform.rotation.eulerAngles.x <= 180)
     //      {
     //          transform.rotation = Quaternion.Euler(MaxAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
     //      }
     //      if (transform.rotation.eulerAngles.x > 180)
     //      {
     //          transform.rotation = Quaternion.Euler((360 - MaxAngle), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
     //      }
     //  }
     //  if (transform.rotation.eulerAngles.z > MaxAngle && transform.rotation.eulerAngles.z < (360 - MaxAngle))
     //  {
     //      if (transform.rotation.eulerAngles.z <= 180)
     //      {
     //          transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, MaxAngle);
     //      }
     //      if (transform.rotation.eulerAngles.z > 180)
     //      {
     //          transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, (360 - MaxAngle));
     //      }
     //  }




        //Charging
        if (Input.GetAxis("Jump") != 0)
        {
            Top.transform.Translate((Bottom.transform.position - Top.transform.position) * ChargeSpeed);
        }
    }
    
}
