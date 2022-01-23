namespace Hospital.UI
{
    // This is the director which ensures the correct build
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildName();
            builder.BuildDescription();
            builder.BuildDurationInHours();
            builder.BuildPatientId();
            builder.BuildDoctorId();
            builder.BuildStartsAt();
            builder.BuildBedId();
        }
    }
}
