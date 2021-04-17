using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;


    public Slider PlayerHealthBar;
    public Text PlayerHealthBarText;

    private float PlayerHealthValue;

    private void Awake()
    {
        Instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthValue = GameManager.Instance.player.PlayerMaxHealth;
        UpdatePlayerHealthBar(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdatePlayerHealthBar(float _value)
    {

        PlayerHealthValue += _value;
        PlayerHealthBar.value = PlayerHealthValue;
        PlayerHealthBarText.text = PlayerHealthValue + "/" + GameManager.Instance.player.PlayerMaxHealth;
    }

    
}
