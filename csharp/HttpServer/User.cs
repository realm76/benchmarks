﻿using static System.DateTime;

namespace HttpServer;

public struct User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; } = Now;
}
