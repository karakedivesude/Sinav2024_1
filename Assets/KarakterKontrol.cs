using System;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KarakterKontrol : MonoBehaviour
{
    // Ad Soyad: 
    // Öğrenci Numarası: 


    // Soru 1: Karakteri yön tuşları ile hareket ettiren kodu, HareketEt fonksiyonu içerisine yazınız.
    // Soru 2: Karakterin zıplamasını sağlaması beklenen Zipla metodu doğru bir şekilde çalışmıyor, koddaki hatayı düzeltin.
    // Soru 3: Karakterin 'Engel' tag'ine sahip objeye temas ettiğinde metin objesine "Oyun Bitti!" yazısını yazdırınız.
    // Soru 4: Karakterin 'Puan' tag'ine sahip objeye temas ettiğinde skoru 1 arttırınız ve metin objesine yazdırınız.

    // Not: Engel ve Puan nesnelerinin isTrigger özelliği aktiftir.

    

    public TMP_Text metin;
    private Rigidbody2D karakterRb;

    public float hiz = 5f;
    public float ziplamaGucu = 5f;

    public int skor = 0;

    void Start()
    {
        karakterRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HareketEt();
    }


    void HareketEt()
    {
        if (Input.GetKey(KeyCode.A))
        {
            karakterRb.AddForce(UnityEngine.Vector2.left * (hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            karakterRb.AddForce(UnityEngine.Vector2.down * (hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            karakterRb.AddForce(UnityEngine.Vector2.right * (hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            karakterRb.AddForce(UnityEngine.Vector2.up * (ziplamaGucu * Time.deltaTime));
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("puan"))
        {
            metin++;
            Destroy(other.gameObject);
            metin.text = "puan:" + metin;

        }

        if(other.gameObject.CompareTag("engel"))
        {
            Destroy(other.gameObject);
            Debug.Log("Oyun bitti!");
        }
    }

    void Zipla()
    {
        // Space tuşuna basınca karakter zıplamalı ancak aşağıdaki kod hatalı.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 ziplamaYonu = new Vector3(UnityEngine.Random.Range(-1f, 1f), 1, UnityEngine.Random.Range(-1f, 1f));
            karakterRb.AddForce(ziplamaYonu * (ziplamaGucu / 2), ForceMode2D.Impulse);
        }
    }
}