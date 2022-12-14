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

    private int foodP;
    private float movementSpeed;
    private float nextWayPointDistance = 3f;

    Animator animator;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb2D;

    public GameObject outputOBJ;
    public GameObject dino;

    private int age;

    private void Awake()
    {
        myFox.setDNA();
        animator = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        movementSpeed = myFox.movementSpeed;
        foodP= myFox.foodP;
        closestFood = null;
        closestCoin = null;
        outputOBJ.GetComponent<output>().newCreature(movementSpeed, myFox.maxHunger, foodP);
        InvokeRepeating("UpdatePath", 0f, 1f);
        age = 0;
    }

    void UpdatePath()
    {
        int i = Random.Range(0, 101);
        if (i < foodP)
        {
            GoFood();
        }
        else
        {
            GoCoin();
        }
    }

    void GoFood()
    {
        if (seeker.IsDone())
        {
            getClosestConsumables();
            seeker.StartPath(rb2D.position, closestFood.position, OnPathComplete);
        }
    }

    void GoCoin()
    {
        if (seeker.IsDone())
        {
            getClosestConsumables();
            seeker.StartPath(rb2D.position, closestCoin.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void FixedUpdate()
    {
        movement();
        if (myFox.hunger >= myFox.maxHunger)
        {
            Destroy(self);
        }
        if (myFox.wealth >= myFox.wealthToReproduce && age > 800)
        {
            reproduce();
            myFox.AdjustWealth(-1 * myFox.wealthToReproduce);
        }
        age++;
    }

    void reproduce()
    {
        reprObj.storeParentDNA(myFox.getDNA());
        Instantiate(self, rb2D.position + new Vector2(1, 1), Quaternion.identity);
    }

    public void getClosestConsumables()
    {
        consumableList = GameObject.FindGameObjectsWithTag("CanBePickedUp");
        if (consumableList != null)
        {
            float closestF = Mathf.Infinity;
            float closestC = Mathf.Infinity;
            Transform transF = null;
            Transform transC = null;

            foreach (GameObject i in consumableList)
            {
                Item currentConsumable = i.GetComponent<Consumable>().item;

                float currentDistance = Vector3.Distance(transform.position, i.transform.position);
                switch (currentConsumable.itemType)
                {
                    case Item.ItemType.COIN:
                        if (currentDistance < closestC)
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
            animator.SetInteger("AnimationState", (int)0);
        }
        if (force.x < 0)
        {
            animator.SetInteger("AnimationState", (int)1);
        }

        float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dino"))
        {
            Destroy(self);
        }
     }
}