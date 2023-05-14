using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    [SerializeField]
    protected Vector3 mouseWorldPos;
    [SerializeField]
    protected float onFiring;

    public static InputManager Instance { get => instance; }
    public Vector3 MouseWorldPos { get => mouseWorldPos; }
    public float OnFiring { get => onFiring;}

    private void Awake()
    {
        if(InputManager.instance != null)
        {
            Debug.LogWarning("Exist two instance of input manager !"); 
            Destroy(gameObject);
        }
        InputManager.instance = this;
    }

    private void FixedUpdate()
    {
        this.GetMouseDown();
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
