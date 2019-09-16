using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Variable type is linked list of gameobjects
    LinkedList<GameObject> segments = new LinkedList<GameObject>();
    public GameObject headPrefab;
    public GameObject bodyPrefab;
    public int startLength = 3;
    public Vector3 direction = Vector3.up;
    public float speed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = GameObject.Instantiate(headPrefab);
        //GameObject obj2 = GameObject.Instantiate(bodyPrefab);

        GameObject head = GameObject.Instantiate(headPrefab);
        head.transform.parent = transform;
        segments.AddLast(head);

        // i = iterator or index
        for(int i = 1; i < startLength; ++i)
        {
            Grow();
        }

        InvokeRepeating("Move", 0f, 1f/speed);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    // function called grow no return typeno arguments
    public void Grow()
    {
        GameObject obj = GameObject.Instantiate(bodyPrefab);
        GameObject tailSegment = segments.Last.Value;
        obj.transform.position = tailSegment.transform.position - tailSegment.transform.forward;
        obj.GetComponent<SpriteRenderer>().sortingOrder = -segments.Count();
        obj.transform.parent = transform;
        segments.AddLast(obj);
    }

    void Move()
    {
        // Move the body
        Vector3 prevPos = Vector3.zero;
        GameObject[] reversed = segments.Reverse().ToArray();
        for( int i = 0; i < reversed.Count()-1; ++i )
        {
            GameObject current = reversed[i];
            GameObject next = reversed[i + 1];

            prevPos = current.transform.position;
            current.transform.position = next.transform.position;
        }

        // Move the head
        GameObject head = segments.First.Value;
        head.transform.position += direction;
        head.transform.rotation = GetDirectionRotation(direction);
    }

    float GetDirectionAngle( Vector3 dir )
    {
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    }

    Quaternion GetDirectionRotation( Vector3 dir )
    {
        float angle = GetDirectionAngle(dir);
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void HandleInput()
    {
        Vector3 nextDir = Vector3.zero;
        nextDir.x = Input.GetAxis("Horizontal");
        nextDir.y = Input.GetAxis("Vertical");

        Transform head = segments.First.Value.transform;
        Transform next = segments.First.Next.Value.transform;
        Vector3 backwards = next.position - head.position;

        if(nextDir.magnitude == 1f && nextDir != backwards)
        {
            direction = nextDir;
        }
    }
}