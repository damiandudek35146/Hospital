using Hospital.Domain.Entities;
using Hospital.Service.Controllers.Interfaces;

namespace Hospital.UI
{
    // A specific implementation for building a treatment
    public class TreatmentBuilder : Builder
    {
        Treatment treatment = new Treatment();
        Dictionary<string, string> registerData = new Dictionary<string, string>();
        Patient patient = new Patient();
        Doctor doctor = new Doctor();
        private readonly IBedController _bedController;
        public TreatmentBuilder(Dictionary<string, string> registerData, Patient patient, Doctor doctor, IBedController bedController)
        {
            this.registerData = registerData;
            this.patient = patient;
            this.doctor = doctor;
            _bedController = bedController;
        }

        public override void BuildName()
        {
            treatment.Name = registerData["Name"];
        }
        public override void BuildDescription()
        {
            treatment.Description = registerData["Description"];
        }
        public override void BuildDurationInHours()
        {
            treatment.DurationInHours = registerData["DurationInHours"];
        }
        public override void BuildBedId()
        {
            var bed = _bedController.Get(int.Parse(registerData["Room number (1-100)"]), int.Parse(registerData["Bed number (1-5)"])).Result;
            treatment.BedId = bed.Id;
        }
        public override void BuildPatientId()
        {
            treatment.PatientId = patient.Id;
        }
        public override void BuildDoctorId()
        {
            treatment.DoctorId = doctor.Id;
        }
        public override void BuildStartsAt()
        {
            treatment.StartsAt = DateTime.Parse(registerData["StartsAt"]);
        }
        public override Treatment GetResult()
        {
            return treatment;
        }
    }
}
