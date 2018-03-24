using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

        ResetAiming();
    }

    void PlayerInput()
    {
        //Aiming
        var h = Input.GetAxis("Vertical") * Time.deltaTime * RotationSpeed;
        var v = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;

        Top.transform.Rotate(h, 0, 0);
        Bottom.transform.Rotate(h, 0, 0);
        Top.transform.Rotate(0, 0, -v);
        Bottom.transform.Rotate(0, 0, -v);

        //Maximum angle
        if (Top.transform.rotation.eulerAngles.x > MaxAngle && Top.transform.rotation.eulerAngles.x < (360 - MaxAngle))
        {
            if (Top.transform.rotation.eulerAngles.x <= 180)
            {
                Top.transform.rotation = Quaternion.Euler(MaxAngle, Top.transform.rotation.eulerAngles.y, Top.transform.rotation.eulerAngles.z);
            }
            if (Top.transform.rotation.eulerAngles.x > 180)
            {
                Top.transform.rotation = Quaternion.Euler((360 - MaxAngle), Top.transform.rotation.eulerAngles.y, Top.transform.rotation.eulerAngles.z);
            }
        }
        if (Top.transform.rotation.eulerAngles.z > MaxAngle && Top.transform.rotation.eulerAngles.z < (360 - MaxAngle))
        {
            if (Top.transform.rotation.eulerAngles.z <= 180)
            {
                Top.transform.rotation = Quaternion.Euler(Top.transform.rotation.eulerAngles.x, Top.transform.rotation.eulerAngles.y, MaxAngle);
            }
            if (Top.transform.rotation.eulerAngles.z > 180)
            {
                Top.transform.rotation = Quaternion.Euler(Top.transform.rotation.eulerAngles.x, Top.transform.rotation.eulerAngles.y, (360 - MaxAngle));
            }
        }
        if (Bottom.transform.rotation.eulerAngles.x > MaxAngle && Bottom.transform.rotation.eulerAngles.x < (360 - MaxAngle))
        {
            if (Bottom.transform.rotation.eulerAngles.x <= 180)
            {
                Bottom.transform.rotation = Quaternion.Euler(MaxAngle, Bottom.transform.rotation.eulerAngles.y, Bottom.transform.rotation.eulerAngles.z);
            }
            if (Bottom.transform.rotation.eulerAngles.x > 180)
            {
                Bottom.transform.rotation = Quaternion.Euler((360 - MaxAngle), Bottom.transform.rotation.eulerAngles.y, Bottom.transform.rotation.eulerAngles.z);
            }
        }
        if (Bottom.transform.rotation.eulerAngles.z > MaxAngle && Bottom.transform.rotation.eulerAngles.z < (360 - MaxAngle))
        {
            if (Bottom.transform.rotation.eulerAngles.z <= 180)
            {
                Bottom.transform.rotation = Quaternion.Euler(Bottom.transform.rotation.eulerAngles.x, Bottom.transform.rotation.eulerAngles.y, MaxAngle);
            }
            if (Bottom.transform.rotation.eulerAngles.z > 180)
            {
                Bottom.transform.rotation = Quaternion.Euler(Bottom.transform.rotation.eulerAngles.x, Bottom.transform.rotation.eulerAngles.y, (360 - MaxAngle));
            }
        }

        //Charging
        if (Input.GetAxis("Jump") != 0)
        {
            //New Vector on taikaluku joka korjaa kahvaosan modelin offsetin
            Top.transform.Translate(((Bottom.transform.position + new Vector3(0, 0, 0.35f)) - Top.transform.position) * ChargeSpeed);
        }
    }
    void ResetAiming()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            Bottom.transform.rotation = Quaternion.Euler(0, 0, 0);
            Top.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
