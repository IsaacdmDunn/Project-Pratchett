using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBug : MonoBehaviour
{

    [SerializeField] Vector3 pivetAround;
    [SerializeField] float pivetSpeed = 5;
    [SerializeField] Transform leftWing;
    [SerializeField] Transform rightWing;

    [SerializeField] float flapSpeed = 5;
    [SerializeField] float flapAngle = 45;
    [SerializeField] float flapOffset =15;
    [SerializeField] float flapLift =0.1f;

    [SerializeField] float timeOffset;

    float flapSine;
    // Start is called before the first frame update
    void Start()
    {
        if (pivetAround == new Vector3( 0,0,0))
        {
            pivetAround = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z - 1);
        }
        gameObject.transform.RotateAround(pivetAround, new Vector3(0, 1, 0), Random.Range(0,360));
        timeOffset = Random.Range(0, 100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flapSine = flapAngle * Mathf.Sin((Time.time + timeOffset) * flapSpeed) + flapOffset;
        leftWing.localRotation = Quaternion.Euler(0, flapSine, 0);
        rightWing.localRotation = Quaternion.Euler(0, -flapSine, 0);

        gameObject.transform.RotateAround(pivetAround, new Vector3(0, -1, 0), Time.deltaTime * pivetSpeed);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    -(flapLift * Mathf.Sin((Time.time + timeOffset) * flapSpeed)) + gameObject.transform.position.y,
                                                    gameObject.transform.position.z);
    }
}
