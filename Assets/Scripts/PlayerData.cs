using System;

[Serializable]
public class PlayerData
{
    public int[] levelOffsetArray;

    public int[] completeArray;

    public int[] movesPerfectArray;

    public int[] movesTakenArray;

    public int[] starsArray;

    public int[] timeTakenArray;

    public int[] attemptsTakenArray;

    public int[] hintsRemainingArray;

    public long[] hintsLastTimeArray;

    public int[] postcardCompleteStateArray;

    public PlayerData(int levelsPerPack, int numPacks)
    {
        this.levelOffsetArray = new int[levelsPerPack * numPacks];
        this.completeArray = new int[levelsPerPack * numPacks];
        this.movesPerfectArray = new int[levelsPerPack * numPacks];
        this.movesTakenArray = new int[levelsPerPack * numPacks];
        this.starsArray = new int[levelsPerPack * numPacks];
        this.timeTakenArray = new int[levelsPerPack * numPacks];
        this.attemptsTakenArray = new int[levelsPerPack * numPacks];
        this.hintsRemainingArray = new int[levelsPerPack * numPacks];
        this.hintsLastTimeArray = new long[levelsPerPack * numPacks];
        this.postcardCompleteStateArray = new int[numPacks];
    }
}


