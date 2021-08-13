using UnityEngine;

namespace Assets.Scripts.Gameplay
{ 
    public class RaycastFinder : MonoBehaviour
    {
        [SerializeField] private Transform _rayOrigin;

        public Transform RayOrigin => _rayOrigin;

        public T[] FindAllObjectsOfType<T>(Vector3 direction)
        {
            RaycastHit[] allHits = Physics.RaycastAll(new Ray(_rayOrigin.position, direction));
            int counter = 0;
            foreach (var item in allHits)
            {
                if (item.collider.GetComponent<T>() != null)
                    counter++;
            }
            if (counter == 0)
                return null;

            T[] objectsArray = new T[counter];
            counter = 0;
            foreach (var item in allHits)
            {
                T inspectedObject = item.collider.GetComponent<T>();
                if (inspectedObject != null)
                {
                    objectsArray[counter] = inspectedObject;
                    counter++;
                }
            }

            return objectsArray;
        }
    }
}
