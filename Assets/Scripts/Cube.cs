using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject boomBoom;

    private Material mat;

    private Vector4 c_red = new Vector4(1, 0.5f, 0.5f, 1);
    private Vector4 c_redder = new Vector4(1, 0.25f, 0.25f, 1);
    private Vector4 c_reddest = new Vector4(1, 0, 0, 1);
    private Vector4 c_yellow = new Vector4(1, 1, 0.5f, 1);
    private Vector4 c_yellower = new Vector4(1, 1, 0.25f, 1);
    private Vector4 c_yellowest = new Vector4(1, 1, 0, 1);

    private bool isExploding = false;
    private bool isFalling = false;

    private float fallingSpeed;
    private float timeUntilExplode;
    private float timeUntilDestroy;
    private float timeExplodeDelay;
    private float timeFallDelay;
    private float timeUntilFall;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        boomBoom = (GameObject)Resources.Load("prefabs/Explosion", typeof(GameObject));
    }

    void Update()
    {
        //Falling functionality
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
            timeUntilDestroy -= Time.deltaTime;

            if (timeUntilDestroy < 0)
            {
                Destroy(this.gameObject);
            }
        }

        //Exploding functionality
        if (isExploding)
        {
            if (timeUntilExplode < (2 * timeExplodeDelay / 3) && timeUntilExplode > (timeFallDelay / 3))
            {
                mat.color = c_yellower;
            }
            else if (timeUntilExplode < (timeExplodeDelay / 3) && timeUntilExplode > 0)
            {
                mat.color = c_yellowest;
            }
            else if (timeUntilExplode <= 0)
            {
                Destroy(this.gameObject);
                Instantiate(boomBoom, transform.position, transform.rotation);
            }

            timeUntilExplode -= Time.deltaTime;
        }
    }

    public void Fall(float delay, float speed)
    {
        timeFallDelay = delay;
        fallingSpeed = speed;
        timeUntilFall = timeFallDelay;
        timeUntilDestroy = timeFallDelay + (fallingSpeed * 100);

        mat.color = c_red;

        isFalling = true;
    }
    public void Explode(float delay)
    {
        timeExplodeDelay = delay;
        timeUntilExplode = timeExplodeDelay;

        mat.color = c_yellow;
        isExploding = true;
    }
}
