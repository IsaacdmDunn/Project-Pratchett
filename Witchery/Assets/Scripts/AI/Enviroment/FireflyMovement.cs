using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMovement : MonoBehaviour
{

    [SerializeField]List<Transform> flies;
    [SerializeField]List<float> PosYflies;
    [SerializeField]List<float> offsetFlies;
    [SerializeField]Light light;
    [SerializeField]float lightChangeMagnitude = 3;
    [SerializeField]float lightRangeOffset = 20;
    [SerializeField]float lightRangeSpeed = 2;
    [SerializeField] float flyChangeMagnitude = .5f;
    [SerializeField] float flyOffsetY = 2;
    [SerializeField] float flySpeed = .33f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform fly in flies)
        {
            PosYflies.Add(fly.position.y);
            offsetFlies.Add(Random.Range(-100, 100) );
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        light.range = lightChangeMagnitude * Mathf.Sin(Time.time* lightRangeSpeed) + lightRangeOffset;
        for (int i = 0; i < flies.Count; i++)
        {
            flies[i].position = new Vector3(flies[i].position.x, Mathf.Sin((Time.time + offsetFlies[i])* flySpeed) + flyOffsetY * flyChangeMagnitude, flies[i].position.z);
        }

    }
}
