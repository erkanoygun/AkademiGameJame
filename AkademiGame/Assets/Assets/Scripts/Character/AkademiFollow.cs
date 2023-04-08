using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkademiFollow : MonoBehaviour
{
    public float runingAkademi;
    public bool IsDevril;
    private Animator _animator;
    //character running speed ile ayný olmalý
    //elle girmektense otomatik olarak runing sppede eþitlemesi için ne yapýlabilir?
    private void Start()
    {
        IsDevril= false;
        _animator = GetComponent<Animator>();//caching
    }
    private void FixedUpdate()
    {
        transform.position += transform.forward * runingAkademi * Time.fixedDeltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsDevril= true;
            _animator.SetBool("IsDevril", IsDevril);
            Gameover();

        }
    }
    private void Gameover()
    {
        //Gameover screeni gelecek
        //görevleri tamamlayamadýn vb. yazabilir?
    }
}
