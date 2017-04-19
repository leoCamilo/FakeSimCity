namespace Cariacity.game
{
    public abstract class BuildingBehaviour
    {
        public abstract void OnBegan(GridCell cell);
        public abstract void OnMoved(GridCell cell);
        public abstract void OnEnded(GridCell cell);
        public abstract void OnCanceled(GridCell cell);
        public abstract void OnStationary(GridCell cell);
        public abstract void Apply();
        public abstract void Clean();
        public abstract void CtrlZ();
    }
}
