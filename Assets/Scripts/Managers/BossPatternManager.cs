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
    public BossIdle idle;
    public BossStrike strike;
    public BossLaser laser;
    public BossSpiralSpread sprialSpread;
    public BossPrisonDodge prisonDodge;
    public BossPrisonLaser prisonLaser;
    public BossCircleFire circleFire;
    public BossMakePrison makePrison;
    public BossQuartzPattern quartzPattern;

    public BossState curState = BossState.Move;

    public BossState[] patternCycle;
    private int curPatternIndex;

    public void ChangeState(BossState nextState)
    {
        DisableAllPatterns();

        curState = nextState;

        switch (curState)
        {
            case BossState.Move:
                move.enabled = true;
                break;
            case BossState.Idle:
                idle.enabled = true;
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

    public void ExecuteNextPattern()
    {
        if (patternCycle.Length == 0)
            return;

        BossState nextPattern = patternCycle[curPatternIndex];

        ChangeState(nextPattern);
        curPatternIndex++;
    }

    private void DisableAllPatterns()
    {
        move.enabled = false;
        idle.enabled = false;
        strike.enabled = false;
        laser.enabled = false;
        sprialSpread.enabled = false;
        prisonDodge.enabled = false;
        prisonLaser.enabled = false;
        circleFire.enabled = false;
        makePrison.enabled = false;
        quartzPattern.enabled = false;
    }
}
