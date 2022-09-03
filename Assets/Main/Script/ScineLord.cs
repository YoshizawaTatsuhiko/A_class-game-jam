using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScineLord : MonoBehaviour
{
    [SerializeField] GameObject _game;
    [SerializeField] GameObject _game1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scenelord(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void SwtchLight()
    {
        if(_game && _game1)
        {
            _game.SetActive(false);
            _game1.SetActive(true);
        }
    }
}
