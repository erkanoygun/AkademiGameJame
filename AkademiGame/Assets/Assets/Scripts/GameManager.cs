using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject _gameStartPanel;
    [SerializeField] private GameObject _gameOwerPanel;
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _hamerImg;

    [Header("Other")]
    private AkademiFollow _akademiObjectScript;
    [SerializeField] private GameObject _akademiObject;

    [Header("Character")]
    private CharacterManager _characterManagerScript;
    [SerializeField] private GameObject _characterObject;
    void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        _akademiObjectScript = _akademiObject.GetComponent<AkademiFollow>();
        _characterManagerScript = _characterObject.GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_akademiObjectScript.IsDevril)
        {
            StartCoroutine("GameOwer");
        }
        if (_characterManagerScript.isFinish)
        {
            _gameWinPanel.SetActive(true);
            _inGamePanel.SetActive(false);
            Time.timeScale = 0;
        }
        if (_characterManagerScript.isHammer)
        {
            _hamerImg.gameObject.SetActive(true);
        }

    }

    public void StartGame()
    {
        _gameStartPanel.gameObject.SetActive(false);
        _inGamePanel.gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    IEnumerator GameOwer()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOwerPanel.gameObject.SetActive(true);
        _inGamePanel.SetActive(false);
        Time.timeScale = 0;
    }
}
