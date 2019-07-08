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
        // TODO
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

