using Hospital.UI.Decorator;

namespace Hospital.UI.Decorators
{
    // This is an abstraction for specific decorator
    public class Decorator
    {
        protected IComponent component;

        public void SetComponent(IComponent component)
        {
            this.component = component;
        }

        public void EditProfile()
        {
            if(component != null)
            {
                component.EditProfile();
            }
        }
        public void PlannedTreatments()
        {
            if (component != null)
            {
                component.PlannedTreatments();
            }
        }
        public void TreatmentsHistory()
        {
            if (component != null)
            {
                component.TreatmentsHistory();
            }
        }
    }
}
