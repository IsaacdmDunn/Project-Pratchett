using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionNode : Node
{
    Transform transform;
    Transform potentialTarget;
    float viewDistance;
    float FOV = 90f; 
    int layerMask;

    RaycastHit hitInfo;

    public DetectionNode(Transform _transform, float _viewDistance, int _layerMask, Transform _potentialTarget)
    {
        transform = _transform;
        potentialTarget = _potentialTarget;
        viewDistance = _viewDistance;
        layerMask = _layerMask;
        layerMask = ~layerMask;
        
    }

    public override NodeState Evaluate()
    {
        GameObject go = new GameObject();
        go.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        go.transform.rotation = transform.rotation;

        float offset = transform.localEulerAngles.y;

        if (Distance(transform.position.x, transform.position.z, potentialTarget.position.x, potentialTarget.position.z) < viewDistance)
        {
            float angle = Vector3.Angle(potentialTarget.position-transform.position, transform.forward);
            if (angle > (-(FOV/2)) && angle < ((FOV / 2)) )
            {
                if (Physics.Raycast(go.transform.position, (potentialTarget.position - transform.position), out hitInfo, Mathf.Infinity, layerMask))
                {
                    Debug.DrawRay(go.transform.position, (potentialTarget.position - transform.position) * hitInfo.distance, Color.green);


                    return NodeState.success;
                }
            }
            
        }
        


        
        Debug.DrawRay(go.transform.position, go.transform.position- go.transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
        Debug.DrawRay(go.transform.position, (potentialTarget.position - transform.position) * hitInfo.distance, Color.red);
        return NodeState.failure;
    }

    static float Distance(float x1, float y1, float x2, float y2)
    {
        // Calculating distance
        return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) +
                      Mathf.Pow(y2 - y1, 2) * 1.0f);
    }

    float AngleBetweenVec(float x1, float y1, float x2, float y2)
    {
        return Mathf.Atan2(y2 - y1, x2 - x1) * Mathf.Rad2Deg;
    }
}
