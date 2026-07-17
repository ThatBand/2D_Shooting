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
    private BossMove move;
    private BossIdle idle;
    private BossStrike strike;
    private BossLaser laser;
    private BossSpiralSpread sprialSpread;
    private BossPrisonDodge prisonDodge;
    private BossPrisonLaser prisonLaser;
    private BossCircleFire circleFire;
    private BossMakePrison makePrison;
    private BossQuartzPattern quartzPattern;

    public BossState curState = BossState.Move;

    public BossState[] phase1PatternCycle;
    public BossState[] phase2PatternCycle;

    private BossState[] curSequence;

    private bool isPhase2;

    private int curPatternIndex;

    private void Awake()
    {
        move = GetComponent<BossMove>();
        idle = GetComponent<BossIdle>();
        strike = GetComponent<BossStrike>();
        laser = GetComponent<BossLaser>();
        sprialSpread = GetComponent<BossSpiralSpread>();
        prisonDodge = GetComponent<BossPrisonDodge>();
        prisonLaser = GetComponent<BossPrisonLaser>();
        circleFire = GetComponent<BossCircleFire>();
        makePrison = GetComponent<BossMakePrison>();
        quartzPattern = GetComponent<BossQuartzPattern>();
    }

    private void Start()
    {
        curSequence = phase1PatternCycle;

        ChangeState(BossState.Move);
    }

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
        if (curSequence == null || curSequence.Length == 0)
            return;

        BossState nextPattern = curSequence[curPatternIndex];

        ChangeState(nextPattern);
        curPatternIndex++;

        if (curPatternIndex >= curSequence.Length)
            curPatternIndex = 0;
    }

    public void EnterPhase2()
    {
        if (isPhase2)
            return;

        StopAllCoroutines();
        GameManager.instance.ClearBullet();

        isPhase2 = true;
        Debug.Log("보스 2페이즈 시작!");

        curSequence = phase2PatternCycle;
        curPatternIndex = 0;

        ChangeState(BossState.Prison);
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
