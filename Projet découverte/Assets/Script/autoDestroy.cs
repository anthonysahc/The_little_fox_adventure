using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour
{
    public float aliveTime;

    void Start()
    {
        Destroy(gameObject, aliveTime);
    }
}
