namespace Hospital.UI
{
    // Storage for memento
    public class Caretaker
    {
        Memento memento;
        public Memento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }
}
