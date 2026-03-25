using Unity.VisualScripting;
using UnityEngine;

// AI
public class Enemy : Unit
{
    public enum EnemyState
    {
        Idle, Suspect, Move, Attack
    }

    [SerializeField] private float recognizeDist;
    [SerializeField] private string[] targetTags;

    // 1. 거리가 recognizeDist 보다 같거나 작은 가장 가까운 객체를 검사한다.
    // 2. 직선의 방정식으로 적과 나 사이 거리를 잰다.
    
    // 4. 타겟이 정해졌다면 더 이상 계산 X

    // 1. Enemy가 적을 감지한다.
    // 2. Enemy가 적을 향해 이동한다.
    // 3. Enemy가 적을 공격한다.
    // 4. Enemy가 맞으면 공격이 취소된다.
    // 5. Enemy가 맞으면 살짝 멈춘다.


    private void Update()
    {
        
    }
}
