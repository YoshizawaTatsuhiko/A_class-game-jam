using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float _totaltime;
    float _time;
    [SerializeField] Text _timetext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time = Time.deltaTime;
        _totaltime -= _time;
        _timetext.text = $"{_totaltime.ToString("f2")}•b";
        if (_totaltime < 0)
        {
            SceneManager.LoadScene("Gameover");
            _totaltime = 0;
        }
    }
}
