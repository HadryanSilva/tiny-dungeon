using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem deathFx;

    public void Play()
    {
        deathFx.transform.position = transform.position;
        deathFx.Play();
    }
}
