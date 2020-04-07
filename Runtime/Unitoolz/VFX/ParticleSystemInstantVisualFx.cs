using UnityEngine;
namespace DeBox.Unitoolz.VFX
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleSystemInstantVisualFx : BaseInstantVisualFx
    {
        public override void OnPlay()
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
