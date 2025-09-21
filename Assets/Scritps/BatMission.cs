using UnityEngine;
using UnityEngine.Events;

public class BatMission : MonoBehaviour
{
    public UnityEvent OnMissionComplete;
    public UnityEvent OnUpdateAfterMissionComplete;
    public UnityEvent OnMissionIncomplete;

    public static bool BatMissionComplete;
    public static int BatKills;

    private const int batKillsTarget = 12;

    private void Start()
    {
        Debug.Log($"Bat Mission Complete: {BatMissionComplete}");
        if (BatMissionComplete)
        {
            OnUpdateAfterMissionComplete?.Invoke();
        }
        else
        {
            OnMissionIncomplete?.Invoke();
        }
    }

    public void AddBatKill()
    {
        BatKills++;

        if (BatKills >= batKillsTarget)
        {
            BatMissionComplete = true;
            OnMissionComplete?.Invoke();
        }
    }
}
