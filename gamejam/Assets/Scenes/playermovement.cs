using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector3 pos;
    public Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && tr.position == pos)
        {
            pos += Vector3.right;
            Debug.Log("pos: " + pos);
        }
        else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos)
        {
            pos += Vector3.left;
            Debug.Log("pos: " + pos);

        }
        else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos)
        {
            pos += Vector3.up;
            Debug.Log("pos: " + pos);

        }
        else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos)
        {
            pos += Vector3.down;
            Debug.Log("pos: " + pos);

        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
