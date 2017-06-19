using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour {

    EnemyAction enemAction;
    //What is the target
    PlayerController player;
    public Transform target;

    //Time for update path
    public float updateRate = 2f;
    //Basic stuffs
    private Seeker seeker;
    private Rigidbody2D rb;
    //The calculated Path
    public Path path;

    //AI's speed per second
    public float speed = 2f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //max distance from the AI to a waypoint for it to continues to the next waypoint
    public float nextWaypointDistance = 3;
    //Waypoint we current moving toward
    private int currentWaypoint = 0;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        target = player.transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemAction = GetComponent<EnemyAction>();

        if (target == null)
        {
            //Debug.Log("No Target Found!");
            return;
        }

        //Start new path to target yo!! and return result to OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(UpdatePath ());
    }
    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            //TODO: Insert target please!
            yield return null;
        }
        //Start new path to target yo!! and return result to OnPathComplete method
        seeker.StartPath(this.transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete(Path p)
    {
        //Debug.Log("We got a path, Did it have an error???: " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private void movingTowardTarget()
    {
        if(target == null)
        {
            //TODO: Insert target please
            return;
        }
        //Always look at player
        if(path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            if(pathIsEnded)
            {
                return;
            }
            //Debug.Log("End of Path reached.");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to next Waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= dir.magnitude * speed;
        //Move the AI
        if (enemAction.canMove)
        {
            rb.AddForce(dir, fMode);
        }
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if(dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
    private void FixedUpdate()
    {
        movingTowardTarget();
    }
}
