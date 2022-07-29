using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] int _hp;
    [SerializeField] BoxCollider2D _bc;
    [SerializeField] Vector2 _enemyPosition;
    [SerializeField] float _meleeattack;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzlPosition;
    [SerializeField] Transform _cursorPosition;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        //Vector2 dir = _cursorPosition - transform.position;
        //Flip(X, Y);
        _rb.velocity = new Vector2(X * _moveSpeed, Y * _moveSpeed);
        float distance = Vector2.Distance(transform.position, _enemyPosition);
        if (Input.GetButtonDown("Fire1"))
        {
            if(distance <= _meleeattack)
            {
                _bc.enabled = true;
            }
            else
            {
                Instantiate(_bulletPrefab, _muzzlPosition);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            _hp--;
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
    
    void Flip(float H, float V)
    {
        //float D2 = H * H + V * V;
        //Vector3 PlayerRotation = new Vector3(0, 0, 1);
        //transform.rotation = Quaternion.Euler(PlayerRotation * D2);
        //if(H > 0 && V == 0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //else if (H < 0 && V ==0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 180);
        //}
        //else if (V > 0 && H == 0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 270);
        //}
        //else if (V < 0 && H == 0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 90);
        //}
        //else if (V > 0 && H > 0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 320);
        //}
    }
}
