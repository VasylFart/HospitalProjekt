﻿namespace V_Project.Domain;

public class Tag
{
    public int Id { get; set; }

    public string Value { get; set; }

    public Patient Patient { get; set; }

    public Guid PatientId { get; set; }

}
