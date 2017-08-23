using UnityEngine;
using System.Collections;

public class DeactivateParticle : MonoBehaviour
{
    [Tooltip("Deactivate gameObject on Awake.")]
    public bool startInactive;

    ParticleSystem particle;
    float delay;

    void Awake()
    {
        particle = GetComponent<ParticleSystem>();

        if (particle != null) delay = particle.startLifetime;

        //if (particle == null)
        {
            foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
            {
                delay += Mathf.Max(delay, p.startLifetime);
            }
        }

        gameObject.SetActive(!startInactive);
    }

    void OnEnable()
    {
        if (gameObject.activeInHierarchy) Invoke("Deactivate", delay);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
