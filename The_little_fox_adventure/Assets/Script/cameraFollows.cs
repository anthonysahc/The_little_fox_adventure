using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class cameraFollows : MonoBehaviour
{
    Transform target;

    public float smoothing = 5f;

    [SerializeField] Vector3 offset;



    void Start()
    {
        target = gameManager.InstanceGame.Player.transform;
        offset.z = -10;
        offset.y = 1;
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 targetCamPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime);
        } 
    }
}