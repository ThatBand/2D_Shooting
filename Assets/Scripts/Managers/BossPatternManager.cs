using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Move,
    Idle,
    Strike,
    Laser,
    Spread,
    PDodge,
    PLaser,
    Circle,
    Prison,
    Quartz
}

public class BossPatternManager : MonoBehaviour
{
    public BossMove move;
    public BossStrike strike;
    public BossLaser laser;
    public BossSpiralSpread sprialSpread;
    public BossPrisonDodge prisonDodge;
    public BossPrisonLaser prisonLaser;
    public BossCircleFire circleFire;
    public BossMakePrison makePrison;
    public BossQuartzPattern quartzPattern;

    public BossState curState = BossState.Move;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void ChangeState(BossState nextState)
    {
        StopAllCoroutines();

        curState = nextState;

        switch (curState)
        {
            case BossState.Move:
                move.enabled = true;
                break;
            case BossState.Strike:
                strike.enabled = true;
                break;
            case BossState.Laser:
                laser.enabled = true;
                break;
            case BossState.Spread:
                sprialSpread.enabled = true;
                break;
            case BossState.PDodge:
                prisonDodge.enabled = true;
                break;
            case BossState.PLaser:
                prisonLaser.enabled = true;
                break;
            case BossState.Circle:
                circleFire.enabled = true;
                break;
            case BossState.Prison:
                makePrison.enabled = true;
                break;
            case BossState.Quartz:
                quartzPattern.enabled = true;
                break;
        }
    }
}
