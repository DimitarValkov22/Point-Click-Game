using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform targetDestination;

    private NavMeshAgent playerNavMesh;
   // private Animator animator;

    bool isPressedSpeedUp = false;
    bool isPressedSpeedDown = false;

    private float speedMultiplier = 1f;
    private float maxSpeed = 5;
    private float minSpeed = 3;


    void Awake()
    {
        playerNavMesh = GetComponent<NavMeshAgent>();
      //  animator = GetComponent<Animator>();
    }
    

    
    void Update()
    {

      //  if (EventSystem.current.IsPointerOverGameObject())
      //  {
      //      return;
      //  }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                targetDestination.transform.position = hitPoint.point;
                playerNavMesh.SetDestination(hitPoint.point);
            }
        }

      //  animator.SetBool("isWalking", playerNavMesh.velocity.magnitude > 1f);
    }

    void FixedUpdate()
    {
        if (isPressedSpeedUp == true && playerNavMesh.speed <= maxSpeed)
        {
            SpeedUp();
            Debug.Log("Successfuly speeded up");
            isPressedSpeedUp = false;
        }

        if (isPressedSpeedDown == true && playerNavMesh.speed >= minSpeed)
        {
            Debug.Log("Successfuly speeded down");
            SpeedDown();
            isPressedSpeedDown = false;
        }
    }

    void SpeedUp()
    {
        playerNavMesh.speed += speedMultiplier;
    }

    void SpeedDown()
    {
        playerNavMesh.speed -= speedMultiplier;
    }

    public void EnableBoolSpeedUp()
    {
        isPressedSpeedUp = true;
    }

    public void EnableBoolSpeedDown()
    {
        isPressedSpeedDown = true;
    }
}
