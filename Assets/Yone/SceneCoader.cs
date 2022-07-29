using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCoader : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    int _score;
    GameObject _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        
        if(_gameManager)
        {
            var GM = _gameManager.GetComponent<Timer>();
            _score = GM._score;
            _scoreText.text = $"{_score}";
        }
    }
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
