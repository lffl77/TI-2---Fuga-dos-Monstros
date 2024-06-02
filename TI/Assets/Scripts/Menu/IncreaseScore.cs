using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) 
    {
        Score.instance.UpdateScore();
        Destroy(this.gameObject); 
    }
}
