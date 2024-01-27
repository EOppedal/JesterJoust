using UnityEngine;

public class Door : MonoBehaviour, IDoor
{
    private Transform _nextRoomPosition;
    
    public Vector2 Enter()
    {
        return transform.GetChild(0).position;
    }
}

interface IDoor
{
    Vector2 Enter();
}