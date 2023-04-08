using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cpointtext;
    [SerializeField] private TextMeshProUGUI _spointtext;
    [SerializeField] private TextMeshProUGUI _aylar;
    private List<string> _ayliste = new List<string> {"Ocak","Þubat","Mart","Nisan","Mayýs","Haziran" };
    private int _index = 0;
    private void Awake()
    {
        _aylar.text = _ayliste[_index];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coursera"))
        {
            Destroy(other.gameObject);
            TotalScores.TotalCoursera++;
            _cpointtext.text = TotalScores.TotalCoursera.ToString() + "/6";
            NextLevel();


        }
        if (other.gameObject.CompareTag("Slack"))
        {
            Destroy(other.gameObject);
            TotalScores.TotalSlack++;
            _spointtext.text = TotalScores.TotalSlack.ToString() + "/10";
            Win();
        }
        
    }
    public void NextLevel()
    {
        if (_index <= 5)
        {
            _index++;
            _aylar.text = _ayliste[_index];

        }
    }
    private void Win()
    {
        if (TotalScores.TotalCoursera >= 6 & TotalScores.TotalSlack >=10)
        {
            //Yeni screene geçecek:"tebrikler akademiyi baþarýyla tamamladýnýz" yazabilir?

        }
    }
}

  
