using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Emortal.Gameplay
{
    public class EF_TimerManager_Util : MonoBehaviour 
    {

        #region Variables
        public int secondsCountdown;
        public string m_timesUpString;
        public Text m_timerText;

        public UnityEvent m_audioTickEvent;

        public float m_timeSinceLevelLoad
        {
            get { return m_timeSinceLevelLoad; }
            set { m_timeSinceLevelLoad = Time.timeSinceLevelLoad; }
        }
        #endregion



        #region Methods
        public void StartTimerButton()
        {
            GameObject timerPanel = gameObject;
            StartTimer();
        }

        public void StartTimer()
        {
            if(m_audioTickEvent != null)
            {
                m_audioTickEvent.Invoke();
            }
             StartCoroutine(SetTimer());
        }


        IEnumerator SetTimer()
        {
            int timer = secondsCountdown;
            while (timer > 0)
            {
                m_timerText.text = timer.ToString();
                yield return new WaitForSeconds(1);
                timer--;

                if(m_audioTickEvent != null)
                {
                    m_audioTickEvent.Invoke();
                }
            }
            m_timerText.text = m_timesUpString ;
        }
        #endregion


    }
}
