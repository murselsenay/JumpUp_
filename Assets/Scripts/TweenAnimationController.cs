using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TweenAnimationController : MonoBehaviour
{

    [SerializeField] GameObject Coin;
    [SerializeField] float _duration = 2f;

    private Vector2 _coinStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        _coinStartPosition = Coin.transform.position;
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CoinAnim()
    {
        Coin.transform.position = _coinStartPosition;
        Coin.transform.DOMove(new Vector2(Coin.transform.position.x, Coin.transform.position.y + 2f), _duration);
    }
}
