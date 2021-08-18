using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemySettings enemySettings;
    public bool gameFinished;
    public int[] SceneIndexs;


    public class EnemySettings
    {
        [Header("BasicEnemy")]
        public float basicSpeed;
        public float basicMaxDistance;
        [Header("BossEnemy")]
        public float bossSpeed;
        public float bossMaxDistance;
    }
}
