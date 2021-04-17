using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector2 CoinTarget;
    public GameObject coinCollectingEffect;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CoinTarget = GameObject.FindGameObjectWithTag("CoinTarget").transform.position; 
            Instantiate(coinCollectingEffect, transform.position, Quaternion.identity);
            GameManager.Instance.UpdateCoinCount(1);
            StartCoroutine(MagnetCoin());
        }
    }

    private IEnumerator MagnetCoin()
    {
        float elapsedTime = 0;
        float distance = 0;


        distance = Vector2.Distance(CoinTarget, transform.position);
        while (distance > 0.1f)
        {
           
            distance = Vector2.Distance(CoinTarget, transform.position);
            elapsedTime += Time.deltaTime * 0.2f;
            transform.position = Vector2.Lerp(transform.position, CoinTarget, elapsedTime);
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
