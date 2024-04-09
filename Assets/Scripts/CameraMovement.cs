using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusUpd.Instance.playing)
        {
            Vector2 inputVector = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputVector.y = +1;
            }
        
            if (Input.GetKey(KeyCode.RightArrow))
            {
                inputVector.y = -1;
            }
        
            if (Input.GetKey(KeyCode.UpArrow))
            {
                inputVector.x = +1;
            }
        
            if (Input.GetKey(KeyCode.DownArrow))
            {
                inputVector.x = -1;
            }

            inputVector = inputVector.normalized;

            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.position += moveSpeed*Time.deltaTime*moveDir ;  
        }
        
    }
}
