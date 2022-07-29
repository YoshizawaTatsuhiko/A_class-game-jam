using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] int _hp;
    [SerializeField] GameObject _blade;
    [SerializeField] GameObject[] _enemyPosition;
    [SerializeField] float _meleeattack;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzlPosition;
    [SerializeField] GameObject _cursorPosition;
    [SerializeField] Text _HPtext;
    GameObject closeEnemy;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        Vector2 dir = _cursorPosition.transform.position - transform.position;
        transform.up = dir;
        _HPtext.text = $"HP:{_hp}";
        _rb.velocity = new Vector2(X * _moveSpeed, Y * _moveSpeed);
        if(_hp <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("‹ßÚUŒ‚");
            StartCoroutine(PlayerAttack());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _hp--;
        }
    }
    IEnumerator PlayerAttack()
    {
        _blade.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _blade.gameObject.SetActive(false);
    }
}
