using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
        private Rigidbody _rb;

        int _life = 1;
        private GameObject _shield;
        private GameObject _imortalShield;
        private bool _haveShield;
        private bool _imortal;
        
        private int _contador;
        
        private float _jumpForce = 6.5f;
        private float _gravityScale = 1.0f;
    #endregion

    #region Functions
    private void Start() 
    {
        _shield = GameObject.FindGameObjectWithTag("CShield");
        _imortalShield = GameObject.FindGameObjectWithTag("IShield");
        _shield.SetActive(false);
        _imortalShield.SetActive(false);
        _haveShield = false;
        _imortal = false;

        _contador = 2;

        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = true;
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
            if(Input.touchCount == 5)
            {
                if(_imortal == false)
                {
                _imortal =  true;
                _imortalShield.SetActive(true);
                }
                else
                {
                    _imortal = false;
                    _imortalShield.SetActive(false);
                }
            }
        }
        EnableDisableShield();
    }

    #region PlayerMoves
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
    #endregion

    #region LifeAndShield
        public void EnableDisableShield()
        {
            if(_haveShield == true)
                _shield.SetActive(true);
            else
                _shield.SetActive(false);
            if(_imortal == true)
            {
                _imortalShield.SetActive(true);
                _contador = 999;
            }
            else
                _imortalShield.SetActive(false);
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
                    GameManager.Instance.GameOver();
                }
            }
        }
    #endregion
    
    #region Collisions
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
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
    #endregion
    #endregion
}
