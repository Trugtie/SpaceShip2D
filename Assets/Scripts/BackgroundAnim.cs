using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnim : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField]
    private Vector3 endPos;

    [SerializeField]
    private float speed;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        MoveLeft();
    }

    private void ResetBG()
    {
        transform.position = startPos;
    }

    private void MoveLeft()
    {
        if (transform.position.x < -endPos.x)
        {
            ResetBG();
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       
        
    }
   
}
