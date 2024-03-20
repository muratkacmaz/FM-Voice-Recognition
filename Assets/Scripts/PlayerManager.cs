using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    private List<string> _playerChangeSentences = new List<string>
    {
        "Swap the striker, Erling Haaland, with Alvarez for a fresh attacking approach.",
        "Switch the midfielder, Kovacic, for Phil Foden to inject creativity into the midfield.",
        "Change the winger, Jeremy Doku, with Jack Grealish for more dynamic wing play.",
        "Exchange defender, Rodri with Nathan Ake, to provide fresh legs.",
        "Trade the forward position - put Alvarez  in for Erling Haaland.",
        "Rotate the center-backs, Ruben Dias and John Stones, for more defensive stability.",
        "Alternate the fullbacks - Kyle Walker in, Akanji out for better defensive skills.",
        "Toggle the goalkeepers - Scott in for Ederson to give him a rest.",
        "Remove the tired player, Kevin De Bruyne, and drop in Bernardo Silva for fresh energy.",
        "Take out the injured player, John Stones, and add Nathan Ake as a capable substitute.",
        "Withdraw the midfielder, Rodri, and bring in Kalvin for fresh energy.",
        "Alternate the midfielders - Bernardo Silva in, Rodri out for better control.",
        "Toggle the midfield - Bernardo Silva in, Rodri out for better control.",
        "Remove the winger, Jack Grealish, and drop in Phil Foden to spark the attack.",
        "Swap the fullback, Kyle Walker, with Gvardiol for better defensive skills.",
        "Change the lineup to exploit the opponent's weaknesses - bring in Alvarez for Jack Grealish.",
        "Subtract the player, Grealish, and bring in Bernardo Silva for a tactical advantage.",
        "Trade the midfielder, Kalvin, to dominate the midfield."
    };

    private List<string> twoPlayerActions = new List<string>
    {
        "Swap",
        "Switch",
        "Change",
        "Exchange",
        "Trade",
        "Rotate",
        "Alternate",
        "Toggle",
        "Replace",
        "Substitute"
    };
    private List<string> onePlayerActions = new List<string>
    {
        "Remove",
        "Drop",
        "Take out",
        "Subtract",
        "Withdraw",
        "Bring in",
        "Insert",
        "Introduce",
        "Adjust",
        "Exploit",
        "Add",
        "Drop in",
        "Put in",
        "Incorporate",
        "Bring on",
        "Implement",
        "Apply",
        "Utilize",
        "Deploy"
    };
    
    public PlayerInfoCollection PlayerInfoCollection { get; private set; }

    private void Awake()
    {
        Init();
    }

    private async void Init()
    {
        PlayerInfoCollection = await LoadAssetAsync<PlayerInfoCollection>(nameof(PlayerInfoCollection));
    }

    [Button()]
    private void DebugRandom()
    {
        Debug.Log(GetRandomSentence());
    }
    
    private string GetRandomSentence()
    {
        int random = Random.Range(0,_playerChangeSentences.Count-1);
        
        return _playerChangeSentences[random];
    }

    private async Task<T> LoadAssetAsync<T>(string label)
    {
#if UNITY_EDITOR
        var asset = await Addressables.LoadAssetAsync<T>(label).Task;
        if (asset == null)
            Debug.LogError($"Failed to load addressable : {label}");

        return asset;
#endif
    }
}