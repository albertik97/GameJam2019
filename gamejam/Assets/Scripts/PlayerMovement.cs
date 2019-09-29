using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerId = 1;
    public float speed = 6.0f;
    public float step = 1;
    public Vector3 pos;
    private Transform tr;
    public Animation animator;
    public bool freezed = false;

    

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        tr = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.D) && tr.position == pos)
        //{
        //pos += Vector3.right * step;
        //Debug.Log("pos: " + pos);
        //}
        //else if (Input.GetKey(KeyCode.A) && tr.position == pos)
        //{
        //    pos += Vector3.left * step;
        //    Debug.Log("pos: " + pos);

        //}
        //else if (Input.GetKey(KeyCode.W) && tr.position == pos)
        //{
        //    pos += Vector3.up * step;
        //    Debug.Log("pos: " + pos);

        //}
        //else if (Input.GetKey(KeyCode.S) && tr.position == pos)
        //{
        //    pos += Vector3.down * step;
        //    Debug.Log("pos: " + pos);

        //}

        if (GameImputManager.GetKey(playerId == 1 ? GameImputManager.keyMapping[KeyCode.D] : GameImputManager.keyMapping[KeyCode.RightArrow]) && tr.position == pos && !freezed)
        {
            if(pos.x < 18.0f)
                pos += Vector3.right * step;

            transform.eulerAngles = new Vector3(0, 0, 180);
            //Debug.Log("pos: " + pos);
        } else if (GameImputManager.GetKey(playerId == 1 ? GameImputManager.keyMapping[KeyCode.A] : GameImputManager.keyMapping[KeyCode.LeftArrow]) && tr.position == pos && !freezed)
        {
            if(pos.x > -19.0f)
                pos += Vector3.left * step;
            transform.eulerAngles = new Vector3(0, 0, 0);
            //Debug.Log("pos: " + pos);
        } else if (GameImputManager.GetKey(playerId == 1 ? GameImputManager.keyMapping[KeyCode.W] : GameImputManager.keyMapping[KeyCode.UpArrow]) && tr.position == pos && !freezed)
        {
            if(pos.y < 17.0f)
                pos += Vector3.up * step;
            transform.eulerAngles = new Vector3(0, 0, -90);
            //Debug.Log("pos: " + pos);
        } else if (GameImputManager.GetKey(playerId == 1 ? GameImputManager.keyMapping[KeyCode.S] : GameImputManager.keyMapping[KeyCode.DownArrow]) && tr.position == pos && !freezed)
        {
            if (pos.y > -21.0f)
                pos += Vector3.down * step;
            transform.eulerAngles = new Vector3(0, 0, 90);
            //Debug.Log("pos: " + pos);
        }

        //if(tr.position == pos && (  Input.GetAxis("P" + playerId.ToString() + "_Horizontal") != 0 || 
        //                            Input.GetAxis("P" + playerId.ToString() + "_Vertical") != 0))
        //{
        //    pos += new Vector3( Input.GetAxisRaw("P" + playerId.ToString() + "_Horizontal") * step, 
        //                        Input.GetAxisRaw("P" + playerId.ToString() + "_Vertical") * step, 0);


        //}

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("entra col");
        if (col.gameObject.tag == "queso")
        {
            if(playerId == 1)
            {
                Debug.Log("Player1 Wins");
            }
            else
            {
                Debug.Log("Player2 Wins");
            }
        }
    }
}
