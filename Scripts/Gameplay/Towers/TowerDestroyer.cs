using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers
{
    public static class TowerDestroyer
    {
        public static void Destroy(this Tower destroyedTower)
        {
            TowerContainer[] allContainers = GameObject.FindObjectsOfType<TowerContainer>();
            for (int i = 0; i < allContainers.Length; i++) 
            {
                if (allContainers[i].Tower == destroyedTower)
                {
                    allContainers[i].SetOwnedTower(null);
                    break;
                }
            }
            GameObject.Destroy(destroyedTower.gameObject);
        }
    }
}
