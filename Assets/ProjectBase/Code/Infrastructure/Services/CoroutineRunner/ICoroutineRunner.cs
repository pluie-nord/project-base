using System.Collections;
using UnityEngine;

namespace ProjectBase.Code.Infrastructure.Services.CoroutineRunner
{
    /// <summary>
    /// Used to run coroutines from non MonoBehavior classes
    /// </summary>
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}