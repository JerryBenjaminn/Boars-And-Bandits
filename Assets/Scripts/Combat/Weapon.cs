using UnityEngine;

namespace BAB.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField]
        AnimatorOverrideController weaponOverride = null;
        [SerializeField]
        GameObject weaponPrefab = null;
        [SerializeField]
        float damage = 1f;
        [SerializeField]
        float combatRange = 0f;

        public void Spawn(Transform handTransform, Animator animator)
        {
            if(weaponPrefab != null)
            {
                Instantiate(weaponPrefab, handTransform);
            }
            if(weaponOverride != null)
            {
                animator.runtimeAnimatorController = weaponOverride;
            }           
        }
        public float GetDamage()
        {
            return damage;
        }

        public float GetRange()
        {
            return combatRange;
        }
    }

}
