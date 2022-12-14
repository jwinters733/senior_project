using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class dino : MonoBehaviour
{
    private GameObject[] foxList;
    public Transform closestFox;

    public float movementSpeed;
    private float nextWayPointDistance = 3f;

    Animator animator;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb2D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        closestFox = null;
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            getClosestFox();
            seeker.StartPath(rb2D.position, closestFox.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint= 0;
        }
    }

    void FixedUpdate()
    {
        movement();
    }

    public void getClosestFox()
    {
        foxList = GameObject.FindGameObjectsWithTag("Player");
        if (foxList != null)
        {
            float closestF = Mathf.Infinity;
    
            Transform transF = null;

            foreach (GameObject i in foxList)
            {
              
                float currentDistance = Vector3.Distance(transform.position, i.transform.position);
                if (currentDistance < closestF)
                {
                    closestF = currentDistance;
                    transF = i.transform;
                }
            }
            closestFox = transF;
        }
    }

    public void movement()
    {
        if (path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb2D.position).normalized;
        Vector2 force = direction * movementSpeed * Time.deltaTime;

        rb2D.AddForce(force);
        if (force.x > 0)
        {
            animator.SetInteger("animationState", (int)0);
        }
        if (force.x < 0)
        {
            animator.SetInteger("animationState", (int)1);
        }

        float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
}
