namespace Kolokwium1GrupaA.Models.DTOs;

public class AppointmentDTO
{
    public DateTime date { get; set; }
    public PatientDTO patient { get; set; }
    public DoctorDTO doctor { get; set; }
    public List<Appointment_ServicesDTO> appointment_services { get; set; }
    
} 
public class PatientDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime dateOfBirth { get; set; }
}

public class DoctorDTO
{
    public int doctorid { get; set; }
    public string pwz { get; set; }
}

public class Appointment_ServicesDTO
{
    public string name { get; set; }
    public float serviceFee { get; set; }
}

public class Appointment_PutDTO
{
    public int appointmentId { get; set; }
    public int patientId { get; set; }
    public string pwz { get; set; }
    public List<Appointment_ServicesDTO> appointment_services { get; set; }
}
