using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Kolowkwium.Models.DTOs;

namespace Kolowkwium.Services;

public class Service : IService
{
    public readonly string _connectionString = "Server=DESKTOP-SRO51HP\\MSSQLSERVER04;Database=master;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;";


    public async Task<IActionResult> GetRentals(int id)
    {
        
        var rentals = new List<RentalDTO>();
        int id_customer = 0;
        String fname = null;
        String lname = null;

        using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();
        
        using var check = new SqlCommand("SELECT 1 FROM Rental WHERE customer_id = @id", conn);
        check.Parameters.AddWithValue("@id", id);
        
        var exists = await check.ExecuteScalarAsync();
        if (exists == null)
        {
            return new NotFoundObjectResult("Client not found");
        }
        
        using var command = new SqlCommand("SELECT customer_id,first_name,last_name FROM Customer WHERE customer_id = @id", conn);
        command.Parameters.AddWithValue("@id", id);

        using (var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
        {
            while (await reader.ReadAsync())
            {
                id_customer = reader.GetOrdinal("customer_id");
                fname = (String)reader["first_name"];
                lname = (String)reader["last_name"];
            }
        }
        await conn.OpenAsync();
        using var command2 = new SqlCommand(@"
            SELECT r.rental_id,r.rental_date, r.return_date , s.name , m.title, ri.price_at_rental  
                FROM Rental r 
                    Join Status s ON r.status_id = s.status_id 
                    Join Rental_Item ri on r.rental_id = ri.rental_id 
                    Join Movie m on ri.movie_id = m.movie_id
                WHERE r.customer_id = @id", conn);
        command2.Parameters.AddWithValue("@id", id);
        using var reader2 = await command2.ExecuteReaderAsync();
        while (await reader2.ReadAsync())
        {
            
            int idOrdinal = reader2.GetOrdinal("rental_id");
            var rental = new RentalDTO()
            {
                Id = reader2.GetInt32(idOrdinal),
                RentalDate = reader2.GetDateTime(1),
                ReturnDate = reader2.IsDBNull(2) ? null : reader2.GetDateTime(2),
                Status = reader2.GetString(3),
                Movies = new List<MovieDTO>()
            };
            rentals.Add(rental);
            rental.Movies.Add(new MovieDTO()
            {
                title = reader2.GetString(4),
                price = (float)reader2.GetDecimal(5),
            });
        }
        var customer = new CustomerDTO
        {
            Id = id_customer,
            firstName = fname,
            lastName = lname,
            rentals = rentals
        } ;

        return new OkObjectResult(new { Customer = customer });   
    }
    public async Task AddNewRentalAsync(int customerId, CreateRentalRequestDto rentalRequest)
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand();
        
        command.Connection = connection;
        await connection.OpenAsync();
        
        DbTransaction transaction = await connection.BeginTransactionAsync();
        command.Transaction = transaction as SqlTransaction;

        try
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT 1 FROM Customer WHERE customer_id = @IdCustomer;";
            command.Parameters.AddWithValue("@IdCustomer", customerId);
                
            var customerIdRes = await command.ExecuteScalarAsync();
            if(customerIdRes is null){}
                
            
            command.Parameters.Clear();
            command.CommandText = 
                @"INSERT INTO Rental
            VALUES(@IdRental, @RentalDate, @ReturnDate, @CustomerId, @StatusId);";
        
            command.Parameters.AddWithValue("@IdRental", rentalRequest.Id);
            command.Parameters.AddWithValue("@RentalDate", rentalRequest.RentalDate);
            command.Parameters.AddWithValue("@ReturnDate", DBNull.Value);
            command.Parameters.AddWithValue("@CustomerId", customerId);
            command.Parameters.AddWithValue("@StatusId", 1);

            try
            {
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                
            }
            

            foreach (var movie in rentalRequest.Movies)
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT movie_id FROM Movie WHERE Title = @MovieTitle;";
                command.Parameters.AddWithValue("@MovieTitle", movie.Title);
                
                var movieId = await command.ExecuteScalarAsync();
                if(movieId is null){}
                    
                
                command.Parameters.Clear();
                command.CommandText = 
                    @"INSERT INTO Rental_Item
                        VALUES(@IdRental, @MovieId, @RentalPrice);";
        
                command.Parameters.AddWithValue("@IdRental", rentalRequest.Id);
                command.Parameters.AddWithValue("@MovieId", movieId);
                command.Parameters.AddWithValue("@RentalPrice", movie.RentalPrice);
                
                await command.ExecuteNonQueryAsync();
            }
            
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
        

    }
}

