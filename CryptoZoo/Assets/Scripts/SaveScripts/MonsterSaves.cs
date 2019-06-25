
[System.Serializable]

public class MonsterSaves{
    //public int testhunger;
    public float[] boredomArray;
    public float[] hungerArray;
    public int[] monsterNumValue;

   
    public MonsterSaves (GameManager gameManager)
    {
        gameManager = GameManager.Instance;
        //testhunger = monsterData.Hunger;
        //bordum = monsterData.Bordum;

        hungerArray = gameManager.localHunger;
        boredomArray = gameManager.localBoredom;
        monsterNumValue = gameManager.monsterNumValue;
    }

}
