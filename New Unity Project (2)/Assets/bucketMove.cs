using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketMove : MonoBehaviour
{
    public float factor = 0.05f;
    private Vector3 moveVector;
    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        moveVector = new Vector3(1 * factor, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (flag == true)
            {
                transform.position += moveVector;

            }
            if (transform.position.x > 5.990008 )
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (flag == true)
            {
                transform.position -= moveVector;

            }
            if (transform.position.x < -5.950013)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
        }

        // This was added to answer a question.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
