using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputVector.y = +1;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputVector.y = -1;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveSpeed*Time.deltaTime*moveDir ;
        

    }
}
