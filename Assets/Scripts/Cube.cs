using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material mat;

    private Vector4 c_red = new Vector4(1, 0.5f, 0.5f, 1);
    private Vector4 c_redder = new Vector4(1, 0.25f, 0.25f, 1);
    private Vector4 c_reddest = new Vector4(1,   0,   0, 1);

    private bool isFalling = false;
    
    private float fallingSpeed;
    private float timeFallDelay;
    private float timeUntilFall;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (isFalling)
        {
            if (timeUntilFall < (2 * timeFallDelay / 3) && timeUntilFall > (timeFallDelay / 3))
            {
                mat.color = c_redder;
            }
            else if (timeUntilFall < (timeFallDelay / 3) && timeUntilFall > 0)
            {
                mat.color = c_reddest;
            }
            else if (timeUntilFall <= 0)
            {
                transform.Translate(Vector3.up * -fallingSpeed);
            }

            timeUntilFall -= Time.deltaTime;
        }
    }

    public void Fall(float delay, float speed)
    {
        timeFallDelay = delay;
        fallingSpeed = speed;
        timeUntilFall = timeFallDelay;

        mat.color = c_red;

        isFalling = true;
    }
}
