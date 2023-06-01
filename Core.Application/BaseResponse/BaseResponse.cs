﻿namespace Core.Application.BaseResponse;

public class BaseResponse
{
    public bool Success { get; set; }
    public List<string>? Errors { get; set; }
    public object? Data { get; set; }
}