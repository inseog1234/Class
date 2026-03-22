using Unity.VisualScripting;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    // 1. 따라갈 대상
    // 2. 따라갈 속도
    
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float moveSpeed;

    private Vector3 CurPosition;

    private void LateUpdate()
    {
        Vector3 pos = target.position;
        pos.z = transform.position.z;

        CurPosition = pos + (Vector3)offset;

        Vector3 TargetPosition = Vector3.Lerp(transform.position, CurPosition, Time.deltaTime * moveSpeed);
        
        transform.position = TargetPosition;
    }

    public void SetOffsetX(float x) {
        offset.x = x;
    }

}
