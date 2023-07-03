using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataSources/Player")]
public class Player_Data_Source : ScriptableObject
{
    public Player_Component _player { get; set; }
}
