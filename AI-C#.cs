using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Transform hedef;
    public float hiz;
    public float durmaMesafesi;
    public float kacmaMesafesi;
    public bool hasarVer ;
    public bool hasarKes ;
    public GameObject biz;
    public ChaaracterControler chaaracterControler;
    public float EnemyDamage = 10;

    //Oyuncuyu takip et
    void EnemyFallow()
    { 
         //Oyuncuyu kovala
        if (Vector2.Distance(transform.position, biz.transform.position) > durmaMesafesi) 
        {
            transform.position = Vector2.MoveTowards(transform.position, biz.transform.position, hiz *Time.deltaTime);
            Debug.Log("kovaliyor");
        }
        //Oyuncudan kac
        else if (Vector2.Distance(transform.position, biz.transform.position) < kacmaMesafesi)
        {
            Debug.Log("kaciyor");
            transform.position = Vector2.MoveTowards(transform.position,biz.transform.position, -hiz * Time.deltaTime);
        }

    }
    void Start()
    {

    }

    void Update() 
    {
      
        if (hasarVer == true)
        {
          
            if (hasarKes == false)
            { 
                hasarKes = true;
                StartCoroutine(delay());
            }
        }


        EnemyFallow();
       
    }
    //Oyuncunun coliderina girdiginde hasar vermeyi etkinlestir
    void OnTriggerEnter2D(Collider2D other) 
    {
      
        if(other.gameObject.tag == "Player")
        {
          
            hasarVer = true;
        }
            
    }
    //Oyuncunun colliderindan ciktiginda hasar vermeyi etkisizlestir.
       void OnTriggerExit2D(Collider2D other)
    {
        {
            if (other.gameObject.tag == "Player")
            {
                hasarVer = false;
            }

        }
    }
    //Her verilen hasar arasinda 1 saniye bekle
    IEnumerator delay()
    {
        yield return new WaitForSecondsRealtime(1f);
        chaaracterControler.GetDamage(EnemyDamage);
        hasarKes = false;
    
    }
}   
