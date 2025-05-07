using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Kolokwium1GrupaA.Models.DTOs;

namespace Kolokwium1GrupaA.Services;

public class Service: IService
{
    public readonly string _connectionString =
        "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";
        
    public async Task<IActionResult> Get_Appointment(int id)
    {
        AppointmentDTO appointment = null;
        using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();
        
        using var check = new SqlCommand("SELECT 1 FROM Appointment WHERE appoitment_id = @id", conn);
        check.Parameters.AddWithValue("@id", id);
        
        var exists = await check.ExecuteScalarAsync();
        if (exists == null)
        {
            return new NotFoundObjectResult("Client not found");
        }

        using var command = new SqlCommand(@"
            SELECT a.date,d.doctor_id,d.PWZ,p.first_name,p.last_name,p.date_of_birth,s.name,sa.service_fee  FROM Appointment a 
                JOIN Patient p on a.patient_id =  p.patient_id 
                JOIN Doctor d on a.doctor_id = d.doctor_id
                JOIN Appointment_Service sa on a.appoitment_id = sa.appoitment_id
                JOIN Service s on sa.service_id = s.service_id                      
                                  WHERE appoitment_id = @id", conn);
        command.Parameters.AddWithValue("@id", id);
        
        using (var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
        {
            while (await reader.ReadAsync())
            {
                appointment = new AppointmentDTO()
                {
                    date = reader.GetDateTime(0),
                    patient = new PatientDTO()
                    {
                        firstName = reader.GetString(3),
                        lastName = reader.GetString(4),
                        dateOfBirth = reader.GetDateTime(5)
                    },
                    doctor = new DoctorDTO()
                    {
                        doctorid = reader.GetInt32(1),
                        pwz = reader.GetString(2),
                    },
                    appointment_services = new List <Appointment_ServicesDTO>()
                };
                appointment.appointment_services.Add(new Appointment_ServicesDTO()
                {
                    name = reader.GetString(6),
                    serviceFee = reader.GetInt32(7)
                    
                });
            }
        }
return new OkObjectResult(appointment);
    }
}