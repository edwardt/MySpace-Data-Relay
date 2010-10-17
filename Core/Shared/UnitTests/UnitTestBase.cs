using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

// Based on Justin Burtch testing framework 

namespace MySpace.Common.UnitTests
{
	[TestClass]
	public abstract class UnitTestBase
	{
		private TestContext _context;
		private List<TestDecorator> _decorators;

		public TestContext TestContext
		{
			get { return _context; }
			set { _context = value; }
		}

		[TestInitialize]
		public void Initialize()
		{
			_decorators = new List<TestDecorator>();

			MethodInfo testMethod = this.GetType().GetMethod(_context.TestName);
			object[] attributes = testMethod.GetCustomAttributes(false);
			foreach (Attribute attribute in attributes)
			{
				if (attribute is TestAttributeBase)
				{
					TestAttributeBase testAttrib = attribute as TestAttributeBase;
					testAttrib.SetMethodInfo(testMethod);
					testAttrib.TestClassInstance = this;
					TestDecorator decorator = testAttrib.GetTestDecorator();
					decorator.BeforeTestRun();
					_decorators.Add(decorator);
				}
			}

			OnInitialize();
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void OnCleanup()
		{
		}

		[TestCleanup]
		public void Cleanup()
		{
			OnCleanup();

			_decorators.ForEach(delegate(TestDecorator decorator)
			{
				decorator.AfterTestRun();
			});
		}

        /// <summary>
        /// Delegate used to execute code and see if it throws an exception
        /// </summary>
        public delegate void ExpectedExceptionDelegate();

        /// <summary>
        /// Executes the delegate and checks against a certain type of exception
        /// </summary>
        /// <param name="expectedExceptionDelegate">Code to execute</param>
        /// <returns>True if the expected exception is thrown; false otherwise.</returns>
        public bool ExpectedExceptionOccured<T>(ExpectedExceptionDelegate expectedExceptionDelegate) where T : Exception
        {
            if (expectedExceptionDelegate == null)
                return false;
            else
            {
                Exception exception = null;
                try
                {
                    expectedExceptionDelegate();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                if (exception == null)
                    return false;
                else
                {
                    if (exception.GetType() == typeof(T))
                        return true;
                    else
                        return false;
                }
            }
        }
	}
}
