using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] int EnemyId;
    [SerializeField] int EnemyHealth;
    [SerializeField] string EnemyName;
    [SerializeField] Vector2 EnemyPosition;
    [SerializeField] List<Transform> EnemyPathTransforms = new List<Transform>();

    private Rigidbody2D EnemyBody;
    private Vector2[] EnemyPath = { Vector2.zero, Vector2.zero };
   


    [Header("Set Enemy Type")]
    [SerializeField] GameManager.EnemyType EnemyType;
  

    private void Start()
    {
        Application.targetFrameRate = -1;
        CreateEnemyObject(EnemyType);
        EnemyBody = gameObject.GetComponent<Rigidbody2D>();
        EnemyMovement();
    }

    
    private void CreateEnemyObject(GameManager.EnemyType _enemyType)
    {
        GameManager.Enemy Enemy = GameManager.Instance.SelectEnemy(_enemyType);
        EnemyId = Enemy.EnemyId;
        EnemyName = Enemy.EnemyName;
        EnemyHealth = Enemy.EnemyHealth;
    }

    private void EnemyMovement()
    {
        for (int i = 0; i < EnemyPathTransforms.Count; i++)
        {
            EnemyPath[i] = EnemyPathTransforms[i].position;
        }

        EnemyBody.DOPath(EnemyPath, 2.5f, PathType.Linear, PathMode.Sidescroller2D).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear).OnStepComplete(()=>{

            var enemyScale = gameObject.transform.localScale;
            enemyScale.x *= -1;
            gameObject.transform.localScale = enemyScale;


        });
    }
}
