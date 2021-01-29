using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckling : MonoBehaviour
{
    
    public GameObject targetDuckling;
    private Vector3 targetPosition;
    private bool isFound = false;
    public int steps = 1;

    
    private float speed = 9.0f;
    void Start()
    {

    }

    void Update()
    {
        

    }
    void FixedUpdate()
    {
        if (isFound)
        {
            transform.LookAt(targetDuckling.transform);
            targetPosition = new Vector3(targetDuckling.transform.position.x, transform.position.y, targetDuckling.transform.position.z);
            float targetRad = targetDuckling.GetComponent<SphereCollider>().radius;
            float targetDistance = Vector3.Distance(targetPosition, transform.position);
            float length = targetDistance - (2.0f * targetRad);
            transform.Translate(transform.forward * length, Space.World);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (!isFound) {
            if (collisionInfo.collider.name == "Player")
            {
                print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
                if (collisionInfo.gameObject.GetComponent<MoveInteractor>().ducklingStack.Count == 0)
                {
                    targetDuckling = collisionInfo.gameObject;
                }
                else
                {
                    targetDuckling = collisionInfo.gameObject.GetComponent<MoveInteractor>().ducklingStack.Peek();
                }
                isFound = true;
                collisionInfo.gameObject.GetComponent<MoveInteractor>().ducklingStack.Push(gameObject);
            }
        }
    }

}
