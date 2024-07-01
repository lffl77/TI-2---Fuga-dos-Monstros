using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _width = 6f;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        float movement = _speed * Time.deltaTime;
        transform.Translate(Vector3.left * movement);

        if (transform.position.x < _startPosition.x - _width)
        {
            transform.position = _startPosition;
        }
    }
}
