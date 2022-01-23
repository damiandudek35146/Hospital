namespace Hospital.UI.Decorator
{
    // This is an abctraction as superior component of Decorator pattern
    public interface IComponent
    {
        void EditProfile();
        void PlannedTreatments();
        void TreatmentsHistory();
    }
}
