using UnityEngine;

public class PatrolState : IState
{
    private readonly Player _player;

    public PatrolState(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("Entering Patrol State");
    }

    public void Execute()
    {
        Debug.Log("Patrolling...");
        // Логика патрулирования
    }

    public void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }
}
