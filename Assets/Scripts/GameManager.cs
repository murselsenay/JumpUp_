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

    public enum EnemyType { soilEnemy, flyingEnemy };

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject SoilEnemyPrefab;
    [SerializeField] GameObject FireEnemyPrefab;

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

    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 5 / 100;
        style.normal.textColor = Color.yellow;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
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

    public class Enemy
    {
        public int EnemyHealth { get; set; }
        public EnemyType EnemyType { get; set; }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public GameObject EnemyPrefab { get; set; }

    }

    #region Enemies
    public Enemy SelectEnemy(EnemyType enemyType)
    {

        Enemy enemyObject = new Enemy();
        switch (enemyType)
        {
            case EnemyType.soilEnemy:
                enemyObject.EnemyHealth = 20;
                enemyObject.EnemyId = 1;
                enemyObject.EnemyName = "Soil Enemy";
                enemyObject.EnemyPrefab = SoilEnemyPrefab;
                enemyObject.EnemyType = EnemyType.soilEnemy;
                break;
            case EnemyType.flyingEnemy:
                enemyObject.EnemyHealth = 30;
                enemyObject.EnemyId = 2;
                enemyObject.EnemyName = "Fire Enemy";
                enemyObject.EnemyPrefab = SoilEnemyPrefab;
                enemyObject.EnemyType = EnemyType.flyingEnemy;
                break;
            default:
                break;

        }

        return enemyObject;
    }
    #endregion

    private void MovementAnim()
    {

    }
}