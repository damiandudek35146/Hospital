namespace Hospital.UI
{
    // This is an abstraction of strategy pattern which allows two behaviorus
    public abstract class Strategy
    {
        public Facade SystemFasade { get; set; }
        public abstract void Login();
        public virtual void Register() { }
    }
}
