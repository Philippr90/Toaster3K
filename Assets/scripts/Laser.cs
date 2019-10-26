using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    LineRenderer laserline;

    // Use this for initialization
    void Start()
    {
        laserline = GetComponent<LineRenderer>();
        laserline.SetWidth(0.2f, 0.2f);
    }

    void Update()
    {
        laserline.SetPosition(0, startPoint.position);
    }
}
