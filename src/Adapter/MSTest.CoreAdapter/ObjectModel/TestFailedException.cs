// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter.ObjectModel

{
    using System;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter.ObjectModel;

    /// <summary>
    /// Internal class to indicate Test Execution failure
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
    [Serializable]
    internal class TestFailedException : Exception
    {
        public TestFailedException(UnitTestOutcome outcome, string errorMessage)
            : this(outcome, errorMessage, null, null)
        {
        }

        public TestFailedException(UnitTestOutcome outcome, string errorMessage, StackTraceInformation stackTraceInformation)
            : this(outcome, errorMessage, stackTraceInformation, null)
        {
        }

        public TestFailedException(UnitTestOutcome outcome, string errorMessage, Exception realException)
            : this(outcome, errorMessage, null, realException)
        {
        }

        public TestFailedException(UnitTestOutcome outcome, string errorMessage, StackTraceInformation stackTraceInformation, Exception realException) 
            : base (errorMessage, realException)
        {
            Debug.Assert(!string.IsNullOrEmpty(errorMessage), "ErrorMessage should not be empty");

            this.Outcome = outcome;
            this.StackTraceInformation = stackTraceInformation;
        }


        /// <summary>
        /// Stack Trace information associated with the test failure
        /// </summary>
        public StackTraceInformation StackTraceInformation { get; private set; }


        /// <summary>
        /// Outcome of the test case
        /// </summary>
        public UnitTestOutcome Outcome { get; private set; }
    }
}