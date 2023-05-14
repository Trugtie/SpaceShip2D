using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    private void FixedUpdate()
    {
        this.Fly();
    }

    protected virtual void Fly()
    {
        Vector3 direction = Vector3.right;
        transform.parent.Translate(direction * speed * Time.deltaTime);
    }
}
