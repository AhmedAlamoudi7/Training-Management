﻿namespace TrainingManagement.Exceptions
{
	public class InvalidUsernameOrPasswordException : Exception
    {
        public InvalidUsernameOrPasswordException() : base("Duplicate Email Or Phone")
        {

        }
    }
}