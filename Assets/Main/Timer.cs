using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float _totaltime;
    [SerializeField] PlayreState _state = PlayreState.Noamal;
    float _time;
    [SerializeField] Text _timetext;
    public int _score;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(_state == PlayreState.Noamal)
        {
            _totaltime -= Time.deltaTime;
            if(_timetext)
            {
                _timetext.text = $"{_totaltime.ToString("f2")}•b";
            }
        }
        if (_totaltime < 0)
        {
            SceneManager.LoadScene("Gameover");
            _state = PlayreState.Timer0;
            _totaltime = 0;
        }
    }
    public void AddScore(int Score)
    {
        _score += Score;
    }
}
enum PlayreState
{
    Noamal,

    Timer0,
}
