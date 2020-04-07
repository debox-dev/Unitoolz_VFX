using UnityEngine;

namespace DeBox.Unitoolz.VFX.Manager
{
    public class VFXInstantiator
    {
        public virtual T Instantiate<T>(T prefab) where T : Object
        {
            return Object.Instantiate(prefab);
        }

        public virtual void Destroy(Object instance)
        {
            Object.Destroy(instance);
        }
    }
}
