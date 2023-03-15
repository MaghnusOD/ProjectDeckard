using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIStateID
{
    Idle,
    ChasePlayer,
    Death,
    FindWeapon
}

public interface AIState
{
    AIStateID getID();
    void Enter(AIAgent agent);
    void Update(AIAgent agent);
    void Exit(AIAgent agent);

}
