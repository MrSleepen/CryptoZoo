
[System.Serializable]

public class MonsterSaves{
    public int testhunger;
    public int bordum;

   
    public MonsterSaves (MonsterData monsterData)
    {

        testhunger = monsterData.Hunger;
        bordum = monsterData.Bordum;
    }

}
