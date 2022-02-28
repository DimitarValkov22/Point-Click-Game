using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        transform.position = targetTransform.position + offset;
    }
}
