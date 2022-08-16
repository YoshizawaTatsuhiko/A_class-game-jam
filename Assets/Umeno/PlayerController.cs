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
    [SerializeField] AudioSource _bladeAudio;
    [SerializeField] GameObject _circle;
    [SerializeField] AudioSource _circleAudio;
    [SerializeField] GameObject _allRange;
    [SerializeField] AudioSource _allRangeAudio;
    [SerializeField] GameObject[] _enemyPosition;
    [SerializeField] float _meleeattack;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzlPosition;
    [SerializeField] GameObject _cursorPosition;
    [SerializeField] Text _HPtext;
    [SerializeField] Text _dsCountText;
    [SerializeField] Text _sCountText;
    [SerializeField] ParticleSystem _chageEffect;
    bool _isCircle;
    int _sCount;
    Vector3 _playerPosition;
    int _dathSkillCount = 1;
    Rigidbody2D _rb;
    float _timer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        _timer += Time.deltaTime;
        Vector2 dir = new Vector2(X, Y);
        if(dir.magnitude != 0)
        {
            transform.up = dir;
        }
        //Vector3 dir = transform.position - _playerPosition;
        //_playerPosition = transform.position;
        //Vector3 dir = transform.position;
        //if(dir.magnitude > 0.1f)
        //{
        //    Debug.Log("ポジション保存");

        //    _playerPosition = new Vector2(X, Y);
        //    //transform.rotation = Quaternion.AngleAxis(1f, dir);
        //}
        _HPtext.text = $"HP:{_hp}";
        _dsCountText.text = $"使用可能回数:{_dathSkillCount}";
        _sCountText.text = $"使用可能回数:{_sCount}";
        _rb.velocity = new Vector2(X * _moveSpeed, Y * _moveSpeed);
        if(_hp <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("近接攻撃");
            StartCoroutine(PlayerAttackBlead());
            _bladeAudio.Play();
        }
        if(_timer >= 5 && _isCircle == false)
        {
            _sCount = 1;
            _chageEffect.Play();
            _isCircle = true;
        }
        if (Input.GetButtonDown("Fire2") && _isCircle)
        {
            Debug.Log("全体攻撃");
            StartCoroutine(PlayerAttackCircle());
            _circleAudio.Play();
            _timer = 0;
            _sCount = 0;
        }
        if (_dathSkillCount == 1)
        {
            if(Input.GetButtonDown("Fire3"))
            {
                StartCoroutine(PlayreAttackAllRange());
                _allRangeAudio.Play();
                _dathSkillCount = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _hp--;
        }
    }
    IEnumerator PlayerAttackBlead()
    {
        _blade.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _blade.gameObject.SetActive(false);
    }
    IEnumerator PlayerAttackCircle()
    {
        _circle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _circle.gameObject.SetActive(false);
    }
    IEnumerator PlayreAttackAllRange()
    {
        _allRange.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.27f);
        _allRange.gameObject.SetActive(false);
    }
}
