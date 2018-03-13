using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour {


    Vector2 velocity;
    Vector2 steeringForce;

    public float max_speed;
    public float max_velocity;
    public float max_force;
    public float max_avoid;

    public float separation_radius;
    public float max_separation;

    public int mass;

    public Transform evadeTarget;
    public Transform target;

    Vector3 currentTarget;

    public LayerMask obstacleMask;

    GameObject[] all_Unit;

    Vector3[] path;
    int targetIndex;
    // Use this for initialization
    void Start()
    {
        all_Unit = GameObject.FindGameObjectsWithTag("Unit");
        target = GameObject.Find("Target").transform;
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
        }
    }
    
    // Update is called once per frame
    void Update() {
        //velocity = Vector2.zero;
        /*steeringForce = steeringForce + arrival(target.position,3);
        if ((evadeTarget.position - transform.position).magnitude < 3) {
            steeringForce = steeringForce + evade(evadeTarget);
        }*/
        steeringForce = Vector2.zero;
        steeringForce = steeringForce + followPath(path);
        steeringForce = steeringForce + separation();
        steeringForce = steeringForce + obstacleAvoidance();
        //steeringForce = steeringForce + seek(target.transform.position);
        steeringForce = Vector2.ClampMagnitude(steeringForce, max_force);
        steeringForce = steeringForce / mass;
        velocity = Vector2.ClampMagnitude(velocity + steeringForce, max_speed);
        Debug.DrawRay(transform.position + new Vector3(0, 0.2f), new Vector3(velocity.x, velocity.y), Color.green);
        Debug.DrawRay(transform.position + new Vector3(0, -0.2f), new Vector3(velocity.x, velocity.y), Color.green);
        transform.Translate(velocity * Time.deltaTime);
    }

    Vector2 followPath(Vector3[] path) {
        Vector3 target = Vector3.zero;
        if (path != null)
        {
            target = path[targetIndex];
            if ((transform.position - target).magnitude < 0.3f)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    targetIndex = path.Length-1;
                }
            }
        }
        return target != Vector3.zero ? seek(target) : new Vector2();
    }

    Vector2 seek(Vector3 target)
    {
        Vector2 desired_velocity = (target - transform.position).normalized * max_velocity;
        Vector2 steering = desired_velocity - velocity;

        return steering;
    }
    Vector2 flee(Vector3 target) {
        Vector2 desired_velocity = (target - transform.position).normalized * max_velocity;
        Vector2 steering = -desired_velocity - velocity;
        return steering;
    }
    Vector2 arrival(Vector3 target, float radius) {
        Vector2 desired_velocity = target - transform.position;
        float distance = desired_velocity.magnitude;
        if (distance < radius)
        {
            desired_velocity = (desired_velocity).normalized * max_velocity * (distance / radius);
        }
        else {
            desired_velocity = (desired_velocity).normalized * max_velocity;
        }

        Vector2 steering = desired_velocity - velocity;
        return steering;
    }
    Vector2 evade(Transform target) {
        Vector2 distance = target.position - transform.position;
        float updatesAhead = distance.magnitude / target.GetComponent<Steering>().getMaxVelocity();
        Vector3 futurePosition = target.position + new Vector3 ( target.GetComponent<Steering>().getVelocity().x, target.GetComponent<Steering>().getVelocity().y,0)* updatesAhead;
        return flee(futurePosition);
    }
    Vector2 chase(Transform target) {
        Vector2 distance = target.position - transform.position;
        float updatesAhead = 3;
        Vector3 futurePosition = target.position + new Vector3(target.GetComponent<Steering>().getVelocity().x, target.GetComponent<Steering>().getVelocity().y, 0) * updatesAhead;
        return seek(futurePosition);
    }
    Vector2 obstacleAvoidance() {
        Vector2 steering = Vector2.zero;
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, .2f), new Vector3(velocity.x,velocity.y),out hit,1, obstacleMask)) {
            Vector3 diff = transform.position - hit.collider.gameObject.transform.position;
            steering += new Vector2(diff.x,diff.y);
        }
        if (Physics.Raycast(transform.position + new Vector3(0, -0.2f), new Vector3(velocity.x, velocity.y), out hit, 1, obstacleMask))
        {
            Vector3 diff = transform.position - hit.collider.gameObject.transform.position;
            steering += new Vector2(diff.x, diff.y);
        }
        if (Physics.Raycast(transform.position, new Vector3(velocity.x, velocity.y), out hit, 1, obstacleMask))
        {
            //steering += transform.position - hit.collider.gameObject.transform.position + new Vector3(Random.Range(-.5f,.5f),Random.Range(-.5f,.5f),0);;
            Vector3 diff = transform.position - hit.collider.gameObject.transform.position;
            steering += new Vector2(diff.x , diff.y);
        }
        steering = steering.normalized * max_avoid;
        return steering;
    }
    Vector2 separation() {
        Vector2 steering = Vector2.zero;
        int unitCount = 0;
        for (int i = 0; i < all_Unit.Length; i++) {
            GameObject unit = all_Unit[i];
            if (unit != this && distance(unit.transform.position, transform.position) < separation_radius) {
                steering.x += unit.transform.position.x - transform.position.x;
                steering.y += unit.transform.position.y - transform.position.y;
                unitCount++;
            }
        }
        if (unitCount != 0)
        {
            steering.x /= unitCount;
            steering.y /= unitCount;
            steering = steering * -1;
        }

        steering = steering.normalized * max_separation;
        return steering;
    }
    public float getMaxVelocity() {
        return this.max_velocity;
    }
    public Vector2 getVelocity() {
        return this.velocity;
    }
    float distance(Vector3 a, Vector3 b) {
        return ((a - b).magnitude);

    }
    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], new Vector3(0.2f,0.2f,0.2f));

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}
