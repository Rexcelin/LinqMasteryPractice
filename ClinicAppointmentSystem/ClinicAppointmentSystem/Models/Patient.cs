using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicAppointmentSystem.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Contact { get; set; }

        public Patient(int patientId, string name, int age, string contact)
        {
            PatientId = patientId;
            Name = name;
            Age = age;
            Contact = contact;
        }
    }
}
