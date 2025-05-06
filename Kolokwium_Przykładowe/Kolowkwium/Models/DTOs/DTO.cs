namespace Kolowkwium.Models.DTOs;

public class CustomerDTO
{
 public int Id { get; set; }
 public string firstName { get; set; }
 public string lastName { get; set; }
 public List<RentalDTO> rentals { get; set; }
}

public class RentalDTO
{
 public int Id { get; set; }
 public DateTime RentalDate { get; set; }
 public DateTime? ReturnDate { get; set; }
 public string Status { get; set; }
 public List<MovieDTO> Movies { get; set; }
}

public class MovieDTO
{
 public string title { get; set; }
 public float price { get; set; }
}

public class CreateRentalRequestDto
{
 public int Id { get; set; }
 public DateTime RentalDate { get; set; }
 public List<RentedMovieInputDto> Movies { get; set; } = new List<RentedMovieInputDto>();
}

public class RentedMovieInputDto
{
 public string Title { get; set; } = string.Empty;
 public decimal RentalPrice { get; set; }
}