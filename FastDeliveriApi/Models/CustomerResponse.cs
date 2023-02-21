namespace FastDeliveriApi.Models;

public record CustomerResponse(
    int Id,
    string Name,
    string PhoneNumber,
    string Email,
    string Address,
    bool status
);
