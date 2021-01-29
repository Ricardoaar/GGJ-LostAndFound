using UnityEngine;

namespace _scripts
{
    public class CirclePool : ObjectPool
    {
        protected override GameObject CreateObj()
        {
            var obj = Instantiate(prefab, transform, false);
            obj.GetComponent<CircleBehavior>().SetPool(this);
            obj.SetActive(false);
            return obj;
        }
    }
}