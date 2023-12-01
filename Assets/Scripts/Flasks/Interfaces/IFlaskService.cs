using UnityEngine;

namespace Flasks.Interfaces
{
    public interface IFlaskService
    {
        public void AddFlaskContent(IFlaskContent content);
        public void RemoveFlaskContent(IFlaskContent content);
        public bool CanAcceptContent(Vector3 position);
    }
}