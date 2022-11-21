using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FoxBehavior : MonoBehaviour
{
    public GameObject self;
    public organism myFox;
    public replicate reprObj;

    private GameObject[] consumableList;
    public Transform closestFood;
    public Transform closestCoin;

    private float movementSpeed;
    private float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb2D;

    private void Awake()
    {
        myFox.setDNA();
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        movementSpeed = myFox.movementSpeed;
        closestFood = null;
        closestCoin = null;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            getClosestConsumables();
            seeker.StartPath(rb2D.position, closestFood.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void FixedUpdate()
    {
        movement();
        if(myFox.hunger >= myFox.maxHunger)
        {
            Destroy(self);
        }
        if(myFox.wealth >= myFox.wealthToReproduce)
        {
            reproduce();
            myFox.AdjustWealth(-1 * myFox.wealthToReproduce);
        }
    }

    void reproduce()
    {
        reprObj.storeParentDNA(myFox.getDNA());
        Instantiate(self, rb2D.position + new Vector2(1, 1), Quaternion.identity);
    }

    public void getClosestConsumables()
    {
        consumableList = GameObject.FindGameObjectsWithTag("CanBePickedUp");
        if(consumableList!=null) 
        {
            float closestF = Mathf.Infinity;
            float closestC = Mathf.Infinity;
            Transform transF = null;
            Transform transC = null;

            foreach(GameObject i in consumableList)
            {
                Item currentConsumable = i.GetComponent<Consumable>().item;

                float currentDistance = Vector3.Distance(transform.position, i.transform.position);
                switch (currentConsumable.itemType)
                {
                    case Item.ItemType.COIN:
                        if(currentDistance < closestC)
                        {
                            closestC = currentDistance;
                            transC = i.transform;
                        }
                        break;

                    case Item.ItemType.FOOD:
                        if (currentDistance < closestF)
                        {
                            closestF = currentDistance;
                            transF = i.transform;
                        }
                        break;

                    default:
                        break;
                }
            }
            closestFood = transF;
            closestCoin = transC;
        }
    }

    public void movement()
    {
        if(path == null)
        {
            return;
        }
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath= true;
            return;
        } else
        {
            reachedEndOfPath= false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb2D.position).normalized;
        Vector2 force = direction * movementSpeed * Time.deltaTime;

        rb2D.AddForce(force);

        float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentWayPoint]);

        if(distance < nextWayPointDistance) 
        {
            currentWayPoint++;
        }
    }
}
