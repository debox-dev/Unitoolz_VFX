using UnityEngine;

namespace DeBox.Unitoolz.VFX
{
    public class AnimatorInstantVisualFx : BaseInstantVisualFx
    {
        [SerializeField]
        private Animator _animator = null;

        [SerializeField]
        private string _stateName = "Explode";

        public override void OnPlay()
        {
            _animator.Play(_stateName);
        }
    }
}
