﻿namespace V_Project.Domain;

public class Address
{
    public Guid Id { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string HomeNumber { get; set; }

    public Patient Patient { get; set; }

    public Guid PatientId { get; set; }
}
