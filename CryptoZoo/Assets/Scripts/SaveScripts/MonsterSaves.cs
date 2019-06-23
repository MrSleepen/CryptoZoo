
[System.Serializable]

public class MonsterSaves{
    public float testhunger;
    public float bordum;

   
    public MonsterSaves (MonsterData monsterData)
    {

        testhunger = monsterData.Hunger;
        bordum = monsterData.Boredom;
    }

}
