﻿namespace NucleusResult.src
{
    public interface INucleusResult
    {
        bool IsError { get; }
        Error? Error { get; }
    }

    public interface INucleusResult<T> : INucleusResult
    {
        T Data { get; }
    }
}