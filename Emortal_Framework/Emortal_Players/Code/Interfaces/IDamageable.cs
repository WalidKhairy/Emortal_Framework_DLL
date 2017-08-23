using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Players
{
    public interface IDamagable 
    {
        void ApplyDamage(float damageAmount);
    }
}
