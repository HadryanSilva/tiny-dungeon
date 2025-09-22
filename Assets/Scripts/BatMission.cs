using UnityEngine;
using UnityEngine.Events;

public class BatMission : MonoBehaviour
{
    public UnityEvent onMissionComplete;
    public UnityEvent onUpdateAfterMissionComplete;
    public UnityEvent onMissionIncomplete;

    public static bool BatMissionComplete;
    public static int BatKills;

    private const int BatKillsTarget = 12;

    private void Start()
    {
        if (BatMissionComplete)
        {
            onUpdateAfterMissionComplete?.Invoke();
        }
        else
        {
            onMissionIncomplete?.Invoke();
        }
    }

    public void ResetBatCount()
    {
        BatKills = 0;
    }

    public void AddBatKill()
    {
        BatKills++;

        if (BatKills >= BatKillsTarget)
        {
            BatMissionComplete = true;
            onMissionComplete?.Invoke();
        }
    }
}
