using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PlayerBehavior;

namespace Emortal.Core
{

    public class EF_Player_Data_old : MonoBehaviour
    {
        #region Variables
        private static EF_Player_Data_old instance = null;
        public GameObject m_player;
        public string m_playerID;
        public int m_playerRank;

        public float m_initialHealth;
        public float m_currentHealth;
        public bool isDead = false;
        public bool isWinner = false;

//        public PlayerMove m_movementReference;
        // public PlayerInput m_playerInputReference;
        //public PlayerWeapon m_playerWeapon;
        public Camera m_cameraOnPlayer;


        public float m_damageTaken;
        public float m_score;
        public float m_enemyScore;
        public float m_enemyHealth;
        public float m_hitDamage;
        public float m_enemyHitDamage;
        #endregion

        #region Methods
        public static EF_Player_Data_old Instance
        {
            get
            {
                if (EF_Player_Data_old.instance == null)
                {
                    EF_Player_Data_old.instance = new EF_Player_Data_old();
                    DontDestroyOnLoad(EF_Player_Data_old.instance);
                }
                return EF_Player_Data_old.instance;
            }
        }

        public void Start()
        {
            m_player = GameObject.FindGameObjectWithTag("Player");
            if (m_player == null)
            {
                throw new MissingReferenceException("No player in scene.");
            }
            DontDestroyOnLoad(EF_Player_Data_old.instance);
        }

//        public void OnPlayerHit()
//        {
//            m_currentHealth -= m_hitDamage;
//            m_enemyScore += m_enemyHitDamage;
//        }
//
//        public void OnEnemyHit()
//        {
//            m_enemyHealth -= m_hitDamage;
//        }
        #endregion
    }
}