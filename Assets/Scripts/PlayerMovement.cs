using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform targetDestination;

    private NavMeshAgent playerNavMesh;

    bool isPressedSpeedUp = false;
    bool isPressedSpeedDown = false;

    private float speedMultiplier = 1f;
    private float maxSpeed = 5;
    private float minSpeed = 3;


    void Awake()
    {
        playerNavMesh = GetComponent<NavMeshAgent>();
    }
    

    
    void Update()
    {
        // Checking if the player is clicking on the UI buttons
        foreach (var touch in Input.touches)
        {
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }
        }
      

        //Making ray on the point of the input and moving player towards that point
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
    }

    void FixedUpdate()
    {
        //Checking if the player clicked the speedUp button
        if (isPressedSpeedUp == true && playerNavMesh.speed <= maxSpeed)
        {
            SpeedUp();
            Debug.Log("Successfuly speeded up");
            isPressedSpeedUp = false;
        }

        //Checking if the player clicked the speedDown button
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
