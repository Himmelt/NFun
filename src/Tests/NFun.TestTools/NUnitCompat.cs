using System.Collections;

namespace NUnit.Framework;

/// <summary>
/// Compatibility shims for the classic <see cref="CollectionAssert"/> and
/// <see cref="StringAssert"/> APIs that were removed in NUnit 4.
/// They delegate to the constraint model, keeping existing tests compiling.
/// </summary>
public static class CollectionAssert {
    public static void AreEqual(IEnumerable expected, IEnumerable actual, string message = "", params object[] args)
        => Assert.That(actual, Is.EqualTo(expected), message);

    public static void AreEquivalent(IEnumerable expected, IEnumerable actual, string message = "", params object[] args)
        => Assert.That(actual, Is.EquivalentTo(expected), message);
}

public static class StringAssert {
    public static void AreEqualIgnoringCase(string expected, string actual, string message = "", params object[] args)
        => Assert.That(actual, Is.EqualTo(expected).IgnoreCase, message);

    public static void Contains(string expected, string actual, string message = "", params object[] args)
        => Assert.That(actual, Does.Contain(expected), message);

    public static void StartsWith(string expected, string actual, string message = "", params object[] args)
        => Assert.That(actual, Does.StartWith(expected), message);
}
