#region License
// Copyright 2006 James Newton-King
// http://www.newtonsoft.com
//
// This work is licensed under the Creative Commons Attribution 2.5 License
// http://creativecommons.org/licenses/by/2.5/
//
// You are free:
//    * to copy, distribute, display, and perform the work
//    * to make derivative works
//    * to make commercial use of the work
//
// Under the following conditions:
//    * You must attribute the work in the manner specified by the author or licensor:
//          - If you find this component useful a link to http://www.newtonsoft.com would be appreciated.
//    * For any reuse or distribution, you must make clear to others the license terms of this work.
//    * Any of these conditions can be waived if you get permission from the copyright holder.
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.Common.IO.JSON
{
	/// <summary>
	/// The exception thrown when an error occurs while reading Json text.
	/// </summary>
	public class JsonReaderException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonReaderException"/> class.
		/// </summary>
		public JsonReaderException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonReaderException"/> class
		/// with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public JsonReaderException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonReaderException"/> class
		/// with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public JsonReaderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
