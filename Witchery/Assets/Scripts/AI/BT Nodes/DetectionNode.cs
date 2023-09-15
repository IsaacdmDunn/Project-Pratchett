using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//node for finding objects
public class DetectionNode : Node
{
    Transform transform;
    GameObject potentialTarget;
    NPCStats stats;
    float FOV = 270f; 
    int layerMask;

    RaycastHit hitInfo;
    GameObject go = new GameObject();

    //constructor
    public DetectionNode(Transform _transform, NPCStats _stats, int _layerMask, 
        GameObject target)
    {
        transform = _transform;
        potentialTarget = target;
        stats = _stats;
        layerMask = _layerMask;
        layerMask = ~layerMask;
    }

    //runs behaviour
    public override NodeStatus RunBehaviour()
    {
        //create copy of tranform to keep raycast above ground
        go.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        go.transform.rotation = transform.rotation;
        go.transform.SetParent(this.transform);

        //get y angle of agent
        float offset = transform.localEulerAngles.y;

        //checks if detection target is in view range using angles and distance to create cone of vision
        float dist = Distance(transform.position.x, transform.position.z, potentialTarget.transform.position.x, potentialTarget.transform.position.z);
        if (dist < stats.viewDistance)
        {
            if (dist < 10)
            {
                stats.awarenessAmount += stats.awarenessRise;
            }
                

        }
        
        //if spotted return sucess
        if (stats.awareness == NPCStats.Awareness.SPOTTED)
        {
            stats.Speech = "I see something";
            stats.BT = "Detection";
            return NodeStatus.success;
        }
        //return sucess to get AI to move to location NEEDS IMPROVEMENT
        else if (stats.awareness == NPCStats.Awareness.AWARE || stats.awareness == NPCStats.Awareness.SUSPICIOUS)
        {
            stats.Speech = "I think see something";
            stats.BT = "Detection";
            return NodeStatus.success;
        }
        //if awareness is normal then fail
        else
        {
            return NodeStatus.failure;
        }
    }
    //gets distance between 2 objects
    static float Distance(float x1, float y1, float x2, float y2)
    {
        // Calculating distance
        return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) +
                      Mathf.Pow(y2 - y1, 2) * 1.0f);
    }

    //sets NPC target
    public void SetTarget(GameObject _target)
    {
        potentialTarget = _target;
    }

}
