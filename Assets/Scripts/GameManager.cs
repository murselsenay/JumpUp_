using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text CoinText;
    public Text GemText;
    public Player player;

    private void Awake()
    {
        Instance = this;
        SetPlayerProps();
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveCameraUp", 5f);
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    void MoveCameraUp()
    {
        CameraController.Instance.Warn();
    }




    void SetPlayerProps()
    {
         player = new Player();

        //if (!PlayerPrefs.HasKey("PlayerGemCount"))
        PlayerPrefs.SetInt("PlayerGemCount", 0);


        //if (!PlayerPrefs.HasKey("PlayerCoinCount"))
        PlayerPrefs.SetInt("PlayerCoinCount", 0);




        player.PlayerId = 1;
        player.PlayerName = "Test";
        player.PlayerGemCount = PlayerPrefs.GetInt("PlayerGemCount");
        player.PlayerCoinCount = PlayerPrefs.GetInt("PlayerCoinCount");
        player.PlayerMaxHealth = 100f;

        UpdateUIData();
    }


    void UpdateUIData()
    {
        
        CoinText.text = PlayerPrefs.GetInt("PlayerCoinCount").ToString("D6");
        GemText.text = PlayerPrefs.GetInt("PlayerGemCount").ToString("D6");
    }

    public void UpdateCoinCount(int _coinCount)
    {
        int _coinBalance = PlayerPrefs.GetInt("PlayerCoinCount");
        _coinBalance += _coinCount;
        PlayerPrefs.SetInt("PlayerCoinCount", _coinBalance);
        UpdateUIData();
    }
    public void UpdateGemCount(int _gemCount)
    {
        int _gemBalance = PlayerPrefs.GetInt("PlayerGemCount");
        _gemBalance += _gemCount;
        PlayerPrefs.SetInt("PlayerGemCount", _gemBalance);
        UpdateUIData();
    }

    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerGemCount { get; set; }
        public int PlayerCoinCount { get; set; }
        public int PlayerLevel { get; set; }
        public float PlayerMaxHealth { get; set; }


    }


}
