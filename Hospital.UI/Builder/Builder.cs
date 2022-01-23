using Hospital.Domain.Entities;

namespace Hospital.UI
{
    // An abstraction of Builder pattern
    public abstract class Builder
    {
        public abstract void BuildName();
        public abstract void BuildDescription();
        public abstract void BuildDurationInHours();
        public abstract void BuildBedId();
        public abstract void BuildPatientId();
        public abstract void BuildDoctorId();
        public abstract void BuildStartsAt();
        public abstract Treatment GetResult();
    }
}
