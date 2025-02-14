﻿using SpellProject.Battle.Domain.Core.Attack;
using SpellProject.Battle.Domain.Interfaces.Attack;
using UnityEngine;

namespace SpellProject.Battle.Test
{
    public class AttackHitTest : MonoBehaviour, IAttackPassiveController
    {
        public void OnAttacked(AttackParameter attackParameter)
        {
            Debug.Log(attackParameter.OwnerKey);
        }
    }
}