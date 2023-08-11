using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyAI : MonoBehaviour
{
    public float speed = 6000f;
    public float nextWaypointDistance = 1f;

    Path path;
    int currentWaypoint = 0;
    //bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    Transform target;

    void Awake()
    {
        target = gameManager.InstanceGame.Player.transform;
    }

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatPath", 0f, .5f);
    }

    void UpdatPath()
    {
        if(seeker.IsDone() && target)
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            //reachedEndOfPath = true;
            return;
        }else
        {
            //reachedEndOfPath = false;
        }

        Vector2 direction =((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
