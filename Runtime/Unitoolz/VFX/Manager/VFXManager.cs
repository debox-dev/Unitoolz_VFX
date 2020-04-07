using UnityEngine;

namespace DeBox.Unitoolz.VFX.Manager
{
    public class VFXManager : MonoBehaviour
    {
        [SerializeField]
        private bool _isMain = true;

        public static VFXManager Main { get; private set; }

        public VFXInstantiator Instantiator = new VFXInstantiator(); // Implement you own to instantiate from a pool or similar

        private void Start()
        {
            if (_isMain)
            {
                if (Main != null)
                {
                    Debug.LogError("Duplicate VFXManager marked as main!", Main.gameObject);
                    Destroy(gameObject);
                }
                Main = this;
            }
        }

        private void OnDestroy()
        {
            if (Main == null)
            {
                Main = null;
            }
        }

        public T InstantiateFx<T>(T prefab) where T : BaseVisualFX
        {
            var fx = Instantiator.Instantiate(prefab);
            fx.OnFxCreateInternal();
            fx.CompletionPromise.Then(() => DestroyFx(fx)).Catch(e => DestroyFx(fx));
            return fx;
        }

        private void DestroyFx(BaseVisualFX instance)
        {
            instance.OnFxDestroyInternal();
            Instantiator.Destroy(instance.gameObject);
        }
    }

}