using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    #region Variables
    public static ObstacleController obstacleController;
    private float speed = 3.0f;
    private float timerMax = 2.5f;
    private float timer = 0;
    #endregion
    
    #region Functions
    private void Update() 
    {
        ObjectMove();
    }
    public void ObjectMove()
    {
        if(timer >= timerMax)
        {
            speed += speed * (Time.deltaTime / 1);
            timer = 0;
        }
        else
        {
            timer += timer * Time.deltaTime;
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    #endregion
}
