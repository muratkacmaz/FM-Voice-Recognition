using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfoCollection", menuName = "ScriptableObjects/PlayerSO")]
public class PlayerInfoCollection : ScriptableObject
{
    [SerializeField]
    public List<Player> Players;

}

[System.Serializable]
public class Player
{
    public string Name;
    public string Surname;
    public int JerseyNumber;
    public float StarRating;
}
