
[System.Serializable]

public class MonsterSaves{
    //public int testhunger;
    public int[] bordumArray;

    public int[] hungerArray;

   
    public MonsterSaves (GameManager gameManager)
    {
        gameManager = GameManager.Instance;
        //testhunger = monsterData.Hunger;
        //bordum = monsterData.Bordum;

        hungerArray = gameManager.localHunger;
        bordumArray = gameManager.localBoredom;
        
    }

}
