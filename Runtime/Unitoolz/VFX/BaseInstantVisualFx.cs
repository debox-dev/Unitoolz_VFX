using UnityEngine;
using DeBox.Unitoolz.TWeener;
using NaughtyAttributes;

namespace DeBox.Unitoolz.VFX
{
    public abstract class BaseInstantVisualFx : BaseVisualFX
    {

        [SerializeField]
        private bool _autoDestruct = true;

        [ShowIf("_autoDestruct")]
        [SerializeField]
        private float _secondsToDestruct = 2f;

        public void Play()
        {
            OnPlay();
            if (_autoDestruct)
            {
                TweenUtils.Timer(_secondsToDestruct, this)
                    .Then(() => Destruct());
            }
        }

        public abstract void OnPlay();

        protected virtual void Destruct()
        {
            NotifyCompletion();
        }
    }
}
