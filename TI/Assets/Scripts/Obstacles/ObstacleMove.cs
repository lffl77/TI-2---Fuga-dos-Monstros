using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float _speed = 1.5f;
    private float timer = 0;


    private void FixedUpdate() 
    {
        _speed += Time.fixedDeltaTime / 2;
        timer += Time.fixedDeltaTime;
        transform.position +=  Vector3.left * _speed * Time.deltaTime;
        if(timer > 2)
        {
            _speed = _speed + Time.deltaTime;
            timer = 0;
        }
    }
}
