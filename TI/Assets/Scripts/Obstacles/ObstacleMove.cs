using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    #region Variables
    public static ObstacleController obstacleController;
    private float speed = 1.0f;
    private float timerMax = 2.5f;
    private float timer = 0;
    #endregion
    
    #region Functions
    private void FixedUpdate() {
        ObjectMove();
    }
    public void ObjectMove()
    {
        if(timer >= timerMax)
        {
            speed += speed * (Time.fixedDeltaTime * 1.0f);
            timer = 0;
        }
        else
        {
            timer += timer * Time.fixedDeltaTime;
        }
        transform.position = Vector3.left * speed * Time.fixedDeltaTime;
    }
    #endregion
}
