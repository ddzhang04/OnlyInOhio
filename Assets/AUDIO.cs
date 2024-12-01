using UnityEngine;

public class AUDIO : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent ai;
    public Transform player;
    Vector3 dest;

    void Update()
    {
        dest = player.position;
        ai.destination = dest;
    }
}
