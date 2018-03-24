using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Vector4 previousColor;
    private Vector4 nextColor;

    private float timeUntilDestroy;
    private float growSpeed;

    void Start()
    {
        timeUntilDestroy = 0.5f;
        growSpeed = 0.17f;
    }

    void FixedUpdate()
    {
        transform.localScale += new Vector3(growSpeed, growSpeed, growSpeed);

        //Color fade
        previousColor = GetComponent<Renderer>().material.color;
        nextColor = previousColor - new Vector4(0, 0, 0, 0.1f);
        GetComponent<Renderer>().material.color = nextColor;

        if (timeUntilDestroy < 0)
        {
            Destroy(this.gameObject);
        }

        timeUntilDestroy -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(300f, transform.position, 2f);
        }
    }
}
