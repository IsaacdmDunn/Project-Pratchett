using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionNode : Node
{
    Transform transform;
    List<GameObject> potentialTarget;
    EnemyStats stats;
    float FOV = 180f; 
    int layerMask;

    RaycastHit hitInfo;
    GameObject go = new GameObject();
    public DetectionNode(Transform _transform, EnemyStats _stats, int _layerMask, List<GameObject> _potentialTarget,
        GameObject player)
    {
        transform = _transform;
        potentialTarget = _potentialTarget;
        potentialTarget.Add(player);
        stats = _stats;
        layerMask = _layerMask;
        layerMask = ~layerMask;
    }

    public override NodeState Evaluate()
    {
        //create copy of tranform to keep raycast above ground
        go.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        go.transform.rotation = transform.rotation;
        go.transform.SetParent(this.transform);

        //get y angle of agent
        float offset = transform.localEulerAngles.y;


        for (int i = 0; i < potentialTarget.Count; i++)
        {
            //checks if detection target is in view range
            float dist = Distance(transform.position.x, transform.position.z, potentialTarget[i].transform.position.x, potentialTarget[i].transform.position.z);
            if (dist < stats.viewDistance)
            {
                //checks if target is in FOV
                float angle = Vector3.Angle(potentialTarget[i].transform.position - transform.position, transform.forward);
                if (angle > (-(FOV / 2)) && angle < ((FOV / 2)))
                {
                    //if raycast can hit object increase awareness
                    if (Physics.Raycast(go.transform.position, (potentialTarget[i].transform.position - transform.position), out hitInfo, stats.viewDistance, layerMask))
                    {
                        stats.awarenessAmount += stats.awarenessRise / dist * ((float)stats.awareness + 1);

                    }
                }

            }
        }

        //if spotted return sucess
        if (stats.awareness == EnemyStats.Awareness.SPOTTED)
        {
            return NodeState.success;
        }
        //return sucess to get AI to move to location NEEDS IMPROVEMENT
        else if (stats.awareness == EnemyStats.Awareness.AWARE || stats.awareness == EnemyStats.Awareness.SUSPICIOUS)
        {
            return NodeState.success;
        }
        //if awareness is normal then fail
        else
        {
            return NodeState.failure;
        }

        
    }
    //gets distance between 2 objects
    static float Distance(float x1, float y1, float x2, float y2)
    {
        // Calculating distance
        return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) +
                      Mathf.Pow(y2 - y1, 2) * 1.0f);
    }

    public void SetTarget(List<GameObject> _target)
    {
        potentialTarget = _target;
    }

}
