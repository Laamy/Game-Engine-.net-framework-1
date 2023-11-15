using System;
using System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
[ComVisible(true)]
internal sealed class SecurityWarningAttribute : Attribute
{
    public string Message { get; }

    public SecurityWarningAttribute(string message)
    {
        Message = message;
    }
}