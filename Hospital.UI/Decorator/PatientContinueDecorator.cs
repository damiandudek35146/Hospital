
using Hospital.Domain.Entities;
using Hospital.Service.Application;
using Hospital.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Hospital.UI.Decorators
{
    // This is a specific decorator that adds extra behavior after base methods
    public class PatientContinueDecorator : Decorator
    {
        public void EditProfile()
        {
            base.EditProfile();
            PressAnyKeyToContinue();
        }
        public void PlannedTreatments()
        {
            base.PlannedTreatments();
            PressAnyKeyToContinue();
        }
        public void TreatmentsHistory()
        {
            base.TreatmentsHistory();
            PressAnyKeyToContinue();
        }
        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
