using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicAppointmentSystem.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public decimal Fee { get; set; }

        public Doctor(int doctorId, string name,
                      string specialty, decimal fee)
        {
            DoctorId = doctorId;
            Name = name;
            Specialty = specialty;
            Fee = fee;
        }
    }
}
