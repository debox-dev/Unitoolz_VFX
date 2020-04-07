using UnityEngine;
using RSG;

public class BaseVisualFX : MonoBehaviour
{
    public virtual Quaternion Rotation { get => transform.rotation; set => transform.rotation = value; }
    public virtual Vector3 Position { get => transform.position; set => transform.position = value; }

    private Promise _completionPromise;

    public IPromise CompletionPromise => _completionPromise;

    protected virtual void OnFxCreated() { }
    protected virtual void OnFxDestroy() { }


    internal void OnFxCreateInternal()
    {
        _completionPromise = new Promise();
        OnFxCreated();
    }

    internal void OnFxDestroyInternal()
    {        
        OnFxDestroy();
        _completionPromise = null;
    }

    protected void NotifyCompletion()
    {
        _completionPromise.Resolve();
    }

    protected void NotifyError(System.Exception e)
    {
        _completionPromise.Reject(e);
    }    
}
