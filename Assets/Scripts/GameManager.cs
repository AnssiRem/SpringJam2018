using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float BlockFallDelay;
    public float BlockFallSpeed;

    private float timeStart;

    void Start()
    {
        timeStart = Time.time;

        GameObject.Find("/Level/Top Plane/5/6").GetComponent<Cube>().Fall(BlockFallDelay, BlockFallSpeed);
    }

    void Update()
    {

    }
}
