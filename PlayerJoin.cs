using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    // this all comes from https://www.youtube.com/watch?v=u3KoWI92blE
    
    public GameObject playerPrefab;
   private List<Gamepad> joinedGamePads = new List<Gamepad>();
    public GamaManager gM;

    public GameObject[] playerPrefabs;
    public int actives;

    private int noActivePLayers;

    private void Update()
    {
        foreach (var gamePad in Gamepad.all)
        {
            if(gamePad.buttonSouth.wasPressedThisFrame && !joinedGamePads.Contains(gamePad))
            {
                playerPrefab = playerPrefabs[actives];
                
                var player = PlayerInput.Instantiate(playerPrefab, controlScheme: "GamepadM", pairWithDevice: gamePad);
              
                player.transform.position = gM.respawnPoints[PlayerPrefs.GetInt("checkpoint")] + Additive();
                actives++;
                joinedGamePads.Add(gamePad);
                if (actives == 4)
                {
                    gM.SetUpPlayers();
                }
            }
        }

    }

    public Vector2 Additive()
    {
        switch (actives)
        {
            case 0:
                return new Vector2 (-1.5f, 1.5f);

            case 1:
                return new Vector2(1.5f, 1.5f);

            case 2:
                return new Vector2(-1.5f, -1.5f);

            case 3:
                return new Vector2(1.5f, -1.5f);

            default:
                return Vector2.zero;
        }
    }

    public void Start()
    {
       // gM = GameObject.FindWithTag("manager").GetComponent<GamaManager>();
    }
}
