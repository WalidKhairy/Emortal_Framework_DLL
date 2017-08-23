using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using NPCBehavior;

namespace Emortal.Gameplay
{
    public class OnSpawnEvent : UnityEvent<GameObject>
    {
    }

    public class EF_Spawner : MonoBehaviour 
    {
        #region Variables
        [Header("Spawn Properties")]
        public List<GameObject> m_SpawnObjects = new List<GameObject>();
        public int m_SpawnCount = 5;
        public float m_SpawnWaitTime = 1f;

        [Header("Target Properties")]
        public Transform m_Target;

        [Header("Events")]
        public OnSpawnEvent OnSpawned;

        private float lastSpawnTime;
        private int currentSpanwCount;
        private List<GameObject> spawnedObjects = new List<GameObject>();

        private bool m_AllowSpawning = false;
        public bool AllowSpawn
        {
            set
            {
                m_AllowSpawning = value;
                if(m_AllowSpawning)
                {
                    lastSpawnTime = Time.time;
                    currentSpanwCount = 0;
                }
            }
        }
        #endregion

        #region Main Methods
    	// Use this for initialization
        void OnEnable()
        {
            if(OnSpawned == null)
            {
                OnSpawned = new OnSpawnEvent();
            }
        }
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(m_AllowSpawning)
            {
                if(currentSpanwCount < m_SpawnCount)
                {
                    if(Time.time >= lastSpawnTime + m_SpawnWaitTime)
                    {
                        SpawnObjects();
                        lastSpawnTime = Time.time;
                    }
                }
                else
                {
                    m_AllowSpawning = false;
                }
            }
    	}
        #endregion


        #region Util Methods
        void SpawnObjects()
        {
            int randomInt = Random.Range(0, m_SpawnObjects.Count);
            if(randomInt < m_SpawnObjects.Count)
            {
                GameObject curGO = Instantiate(m_SpawnObjects[randomInt], transform.position, Quaternion.identity).gameObject;
                spawnedObjects.Add(curGO);
                currentSpanwCount++;

                if(OnSpawned != null)
                {
                    OnSpawned.Invoke(curGO);
                }
            }
        }

        void RespawnObjects()
        {
            currentSpanwCount = 0;
            lastSpawnTime = Time.time;
            m_AllowSpawning = true;
        }
        #endregion
    }
}
