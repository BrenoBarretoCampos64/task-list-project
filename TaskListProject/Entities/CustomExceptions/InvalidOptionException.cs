﻿namespace TaskListProject.Entities.CustomExceptions
{
    internal class InvalidOptionException : ApplicationException
    {
        public InvalidOptionException(string message) : base(message)
        {
        }
    }
}
