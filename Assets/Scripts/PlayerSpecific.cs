using System;
using UnityEngine;

public class PlayerSpecific : MonoBehaviour
{
    public Player thisPlayer;
    [HideInInspector] public int projectileLayer;
    
    public enum Player
    {
        Player1,
        Player2
    }
    
    private void Awake()
    {
        switch (thisPlayer)
        {
            case Player.Player1:
                gameObject.layer = LayerMask.NameToLayer("Player1");
                projectileLayer = LayerMask.NameToLayer("Player1Projectile");
                break;
            case Player.Player2:
                gameObject.layer = LayerMask.NameToLayer("Player2");
                projectileLayer = LayerMask.NameToLayer("Player2Projectile");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}