using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 6.5f;
    private Rigidbody _rb;
    [SerializeField]private bool haveShield;
    [SerializeField]private bool isGrounded;
    //float shieldTimeRemaining = 5f;

    private void Start() 
    {
        haveShield = false;
        isGrounded = true;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            
            if(t.phase == TouchPhase.Began)
            {
                Jump();
            }      
        }
    }

    private void Jump()
    {
        if(isGrounded == true)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            SoundManager.instanceAudio.Jump();    
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if(other.gameObject.tag == "Coin")
        {
            Score.instance.UpdateScore();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "PowerUP")
        {
            haveShield = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            if(haveShield == false)
            {
                GameManager._gmInstance.GameOver();
                Destroy(this.gameObject);
            }
            else if(haveShield == true)
            {
                Destroy(other.gameObject);
                haveShield = false;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
