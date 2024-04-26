using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 6.5f;
    private Rigidbody _rb;
    [SerializeField]private bool haveShield;
    //[SerializeField]private bool isGrounded;
    [SerializeField]private int Contador;
    int _life = 1;

    private void Start() 
    {
        haveShield = false;
        Contador = 2;
        //isGrounded = true;
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
            /*if(Input.touchCount == 4)
            {

            }*/   
            if(Input.touchCount == 5)
            {
                _life = 999;
            }
        }
    }

    public void Life(int life)
    {
        life = this._life;
        
        life--;
        if(life <= 0)
        {
            Destroy(this.gameObject);
            GameManager._gmInstance.GameOver();
        }
    }

    private void Jump()
    {
        if(Contador > 0)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            SoundManager.instanceAudio.Jump();
            Contador--;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            //isGrounded = true;
            Contador = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Ground")
        {
            //isGrounded = true;
            Contador = 2;
        }*/
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
                Life(1);
            }
            else if(haveShield == true)
            {
                Destroy(other.gameObject);
                haveShield = false;
            }
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //isGrounded = false;
        }
    }*/
}
