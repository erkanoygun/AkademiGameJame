using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkademiFollow : MonoBehaviour
{
    public float runingAkademi;
    private Animator _animator;
    public bool IsDevril;
    public bool testtt = false;
    //character running speed ile ayný olmalý
    //elle girmektense otomatik olarak runing sppede eþitlemesi için ne yapýlabilir?
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (testtt)
        {
            _animator.SetTrigger("Logo");
        }
    }
    private void FixedUpdate()
    {
        transform.position += transform.forward * runingAkademi * Time.fixedDeltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsDevril = true;
            _animator.SetTrigger("Logo");

        }
    }
}
