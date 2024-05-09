using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 6.5f;
    private Rigidbody _rb;
    [SerializeField]private bool _haveShield;
    [SerializeField]private int _contador;
    int _life = 1;
    [SerializeField]private bool _imortal;
    [SerializeField] private float _gravityScale = 1.0f;

    private void Start() 
    {
        _haveShield = false;
        _contador = 2;
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = true;
        _imortal = false;
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
                _imortal =  true;
            }
        }
    }

    public void Life(int life)
    {
        life = this._life;
        
        life--;
        if(life <= 0)
        {
            if(_imortal == false)
            {
            Destroy(this.gameObject);
            GameManager._gmInstance.GameOver();
            }
        }
    }

    private void Jump()
    {
        if(_contador > 0)
        {
            Vector3 newJumpForce = (_jumpForce * _gravityScale * Vector3.up);
            _rb.AddForce(newJumpForce, ForceMode.Impulse);
            SoundManager.instanceAudio.Jump();
            _contador--;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            //isGrounded = true;
            _contador = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Score.instance.UpdateScore();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "PowerUP")
        {
            _haveShield = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            if(_haveShield == false)
            {
                Life(1);
            }
            else if(_haveShield == true)
            {
                Destroy(other.gameObject);
                _haveShield = false;
            }
        }
    }
}
