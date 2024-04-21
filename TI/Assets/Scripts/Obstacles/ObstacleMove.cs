using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float _speed = 1.5f;
    private float timer = 0;


    private void Update() 
    {
        _speed += Time.deltaTime / 2;
        timer += Time.deltaTime;
        transform.position +=  Vector3.left * _speed * Time.deltaTime;
        if(timer > 2)
        {
            _speed = _speed + Time.deltaTime;
            timer = 0;
        }
    }
}
