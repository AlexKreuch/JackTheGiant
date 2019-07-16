using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public static Collectibles instance;

    private class DifficultyUtil {
        // TODO
    }
    public void DifficultyAdjustMent(params object[] data) {
        /*
             At least one argument is expected.
             The 1st argument is expected to be an int, indecating what operation should be carried out.

             if the 1st argument == 0 then : 
                -> there should be 1 more argument, which must be an int, indicating how many lives the player will be allowed to have durring a game

             if the 1st argument == 1 then : 
                -> there should be 1 more argument, which must be a float, indicating the probability of spawning a life durring a game.
         */
        Debug.Assert(data.Length >= 1);
        int c = (int)data[0];
        switch (c)
        {
            case 0:
                Debug.Assert(data.Length == 2);
                MaxLives = (int)data[1];
                break;
            case 1:
                Debug.Assert(data.Length == 2);
                lifeProb = (float)data[1];
                break;
        }
    }

    #region fields for constructing collectables
    [SerializeField]
    private GameObject Blank;
    [SerializeField]
    private Sprite coinSprite, lifeSprite;
    private const string coinTag = "Coin";
    private const string lifeTag = "Life";
    private const string coinName = "CollectibleCoin";
    private const string lifeName = "CollectibleLife";
    #endregion

    #region fields for counting colletables
    private int lifeCount = 0;
    [SerializeField]
    private int MaxLives = 2;
    [SerializeField]
    private float lifeProb = .5f;

    [SerializeField]
    private Player_Score player_Score;
    #endregion

    public void SetUpCollectable(Collectible collectible) {
        int pick = PickType();
        switch (pick)
        {
            case 0:
                collectible.name = coinName;
                collectible.SetVals(coinSprite,coinTag);
                break;
            case 1:
                lifeCount++;
                collectible.name = lifeName;
                collectible.SetVals(lifeSprite, lifeTag);
                break;
        }
    }
    public void ReportDestruction(GameObject obj) {
        if (obj.tag == lifeTag) lifeCount--;
    }

    private int PickType() {
        // 0:=Coin ; 1:=Life
        if (lifeCount+player_Score.lifeScore >= MaxLives) return 0;
        float r = Random.Range(0f, 1f);
        return r < lifeProb ? 1 : 0 ;
    }
    public void Awake() {
        instance = this;
    }
    public GameObject MakeCollectable(Vector2 position)
    {
        GameObject result = Instantiate(Blank);
        if (result == null) return null;
        Collectible collectible = result.GetComponent<Collectible>();
        if (collectible == null) return null;
        collectible.Init(this);
        result.transform.position = position;
        return result;
    }
}

