using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;

namespace ImmediateReflection.Tests
{
    /// <summary>
    /// Helpers to make tests related to constructors.
    /// </summary>
    internal static class ConstructorTestHelpers
    {
        #region Test classes

        public struct ParameterConstructorStruct
        {
            // ReSharper disable once UnusedParameter.Local
            // ReSharper disable once UnusedMember.Local
            public ParameterConstructorStruct(int value)
            {
            }
        }

        public class DefaultConstructor
        {
            public override bool Equals(object obj)
            {
                return Equals(obj as DefaultConstructor);
            }

            private bool Equals(DefaultConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public abstract class AbstractDefaultConstructor
        {
        }

        public abstract class AbstractNoConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            public AbstractNoConstructor(int value)
            {
            }
        }

        public class NoDefaultConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            public NoDefaultConstructor(int value)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as NoDefaultConstructor);
            }

            private bool Equals(NoDefaultConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class MultiParametersConstructor
        {
            // ReSharper disable UnusedParameter.Local
            public MultiParametersConstructor(int value, float value2)
            // ReSharper restore UnusedParameter.Local
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as MultiParametersConstructor);
            }

            private bool Equals(MultiParametersConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class NotAccessibleDefaultConstructor
        {
            private NotAccessibleDefaultConstructor()
            {
            }
        }

        public class NotAccessibleConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            private NotAccessibleConstructor(int value)
            {
            }
        }

        // ReSharper disable once UnusedTypeParameter
        public struct TemplateStruct<TTemplate>
        {
        }

        // ReSharper disable once UnusedTypeParameter
        public class TemplateDefaultConstructor<TTemplate>
        {
            public override bool Equals(object obj)
            {
                return Equals(obj as TemplateDefaultConstructor<TTemplate>);
            }

            private bool Equals(TemplateDefaultConstructor<TTemplate> other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        // ReSharper disable once UnusedTypeParameter
        public class TemplateNoDefaultConstructor<TTemplate>
        {
            // ReSharper disable once UnusedParameter.Local
            public TemplateNoDefaultConstructor(int value)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as TemplateNoDefaultConstructor<TTemplate>);
            }

            private bool Equals(TemplateNoDefaultConstructor<TTemplate> other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class DefaultConstructorThrows
        {
            // ReSharper disable once UnusedMember.Local
            public DefaultConstructorThrows()
            {
                throw new InvalidOperationException("Constructor throws.");
            }

            // ReSharper disable once UnusedMember.Local
            // ReSharper disable once UnusedParameter.Local
            public DefaultConstructorThrows(int value)
            {
                throw new InvalidOperationException("Constructor throws (int).");
            }

            // ReSharper disable once UnusedMember.Local
            // ReSharper disable UnusedParameter.Local
            public DefaultConstructorThrows(int value, float value2)
            // ReSharper restore UnusedParameter.Local
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as DefaultConstructorThrows);
            }

            private bool Equals(DefaultConstructorThrows other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class NotDefaultConstructorThrows
        {
            // ReSharper disable once UnusedParameter.Local
            public NotDefaultConstructorThrows(int value)
            {
                throw new InvalidOperationException("Constructor throws.");
            }
        }

        public class MultipleConstructors
        {
            // ReSharper disable UnusedMember.Local
            public MultipleConstructors()
            {
            }

            // ReSharper disable UnusedParameter.Local
            public MultipleConstructors(int value)
            {
            }

            public MultipleConstructors(int value, float value2)
            {
            }

            // ReSharper restore UnusedParameter.Local
            // ReSharper restore UnusedMember.Local
            public override bool Equals(object obj)
            {
                return Equals(obj as MultipleConstructors);
            }

            private bool Equals(MultipleConstructors other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class ParamsOnlyConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            public ParamsOnlyConstructor(params object[] args)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as ParamsOnlyConstructor);
            }

            private bool Equals(ParamsOnlyConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class ParamsConstructor
        {
            // ReSharper disable UnusedParameter.Local
            public ParamsConstructor(int value, params object[] args)
            // ReSharper restore UnusedParameter.Local
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as ParamsConstructor);
            }

            private bool Equals(ParamsConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class AmbiguousParamsOnlyConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            // ReSharper disable once UnusedMember.Local
            public AmbiguousParamsOnlyConstructor(params object[] args)
            {
            }

            // ReSharper disable once UnusedParameter.Local
            // ReSharper disable once UnusedMember.Local
            public AmbiguousParamsOnlyConstructor(params int[] args)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as ParamsOnlyConstructor);
            }

            private bool Equals(ParamsOnlyConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class IntParamsOnlyConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            public IntParamsOnlyConstructor(params int[] args)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as IntParamsOnlyConstructor);
            }

            private bool Equals(IntParamsOnlyConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class NullableIntParamsOnlyConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            public NullableIntParamsOnlyConstructor(params int?[] args)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as NullableIntParamsOnlyConstructor);
            }

            private bool Equals(NullableIntParamsOnlyConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class DefaultInheritedDefaultConstructor : DefaultConstructor
        {
        }

        public class DefaultInheritedNoDefaultConstructor : NoDefaultConstructor
        {
            public DefaultInheritedNoDefaultConstructor()
                : base(777)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as DefaultInheritedNoDefaultConstructor);
            }

            private bool Equals(DefaultInheritedNoDefaultConstructor other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class DefaultInheritedFromAbstractClass : AbstractDefaultConstructor
        {
            public override bool Equals(object obj)
            {
                return Equals(obj as DefaultInheritedFromAbstractClass);
            }

            private bool Equals(DefaultInheritedFromAbstractClass other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public class NoDefaultInheritedDefaultConstructor : DefaultConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            public NoDefaultInheritedDefaultConstructor(int value)
            {
            }
        }

        public class NoDefaultInheritedNoDefaultConstructor : NoDefaultConstructor
        {
            public NoDefaultInheritedNoDefaultConstructor(int value)
                : base(value)
            {
            }
        }

        public class NoDefaultInheritedFromAbstractClass : AbstractDefaultConstructor
        {
            // ReSharper disable once UnusedParameter.Local
            public NoDefaultInheritedFromAbstractClass(int value)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as NoDefaultInheritedFromAbstractClass);
            }

            private bool Equals(NoDefaultInheritedFromAbstractClass other)
            {
                if (other is null)
                    return false;
                return true;
            }

            public override int GetHashCode()
            {
                return 1;
            }
        }

        public static class StaticClass
        {
        }

        #endregion

        #region New/TryNew

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateDefaultConstructorTestCases
        {
            [UsedImplicitly]
            get
            {
                yield return new TestCaseData(typeof(int));
                yield return new TestCaseData(typeof(TestStruct));
                yield return new TestCaseData(typeof(DefaultConstructor));
                yield return new TestCaseData(typeof(MultipleConstructors));
                yield return new TestCaseData(typeof(TemplateStruct<double>));
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<int>));
                yield return new TestCaseData(typeof(DefaultInheritedDefaultConstructor));
                yield return new TestCaseData(typeof(DefaultInheritedNoDefaultConstructor));
                yield return new TestCaseData(typeof(DefaultInheritedFromAbstractClass));
                yield return new TestCaseData(typeof(List<int>));
                yield return new TestCaseData(typeof(Dictionary<int, string>));
            }
        }

        public static void NewParameterLess([NotNull] Type type, [NotNull, InstantHandle] Func<object> ctor)
        {
            object instance = ctor();
            Assert.IsNotNull(instance);
            Assert.AreEqual(Activator.CreateInstance(type), instance);
        }

        public static void NewParamsOnly([NotNull, InstantHandle] Func<object> ctor, [NotNull, InstantHandle] Func<object> expectedObject)
        {
            object instance = ctor();
            Assert.IsNotNull(instance);
            Assert.AreEqual(expectedObject(), instance);
        }

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateDefaultConstructorNoThrowTestCases
        {
            [UsedImplicitly]
            get
            {
                yield return new TestCaseData(typeof(int), false);
                yield return new TestCaseData(typeof(TestStruct), false);
                yield return new TestCaseData(typeof(DefaultConstructor), false);
                yield return new TestCaseData(typeof(MultipleConstructors), false);
                yield return new TestCaseData(typeof(TemplateStruct<double>), false);
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<int>), false);
                yield return new TestCaseData(typeof(DefaultInheritedDefaultConstructor), false);
                yield return new TestCaseData(typeof(DefaultInheritedNoDefaultConstructor), false);
                yield return new TestCaseData(typeof(DefaultInheritedFromAbstractClass), false);
                yield return new TestCaseData(typeof(List<int>), false);
                yield return new TestCaseData(typeof(Dictionary<int, string>), false);

                yield return new TestCaseData(typeof(NoDefaultConstructor), true);
                yield return new TestCaseData(typeof(NotAccessibleDefaultConstructor), true);
                yield return new TestCaseData(typeof(IList<int>), true);
                yield return new TestCaseData(typeof(IDictionary<int, string>), true);
                yield return new TestCaseData(typeof(AbstractDefaultConstructor), true);
                yield return new TestCaseData(typeof(StaticClass), true);
                yield return new TestCaseData(typeof(TemplateStruct<>), true);
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<>), true);
                yield return new TestCaseData(typeof(NoDefaultInheritedDefaultConstructor), true);
                yield return new TestCaseData(typeof(NoDefaultInheritedNoDefaultConstructor), true);
                yield return new TestCaseData(typeof(NoDefaultInheritedFromAbstractClass), true);
                // ReSharper disable once PossibleMistakenCallToGetType.2
                yield return new TestCaseData(typeof(DefaultConstructor).GetType(), true);
                yield return new TestCaseData(typeof(DefaultConstructorThrows), true);
            }
        }

        public delegate bool TryCtor(out object instance, out Exception exception);

        public static void TryNewParameterLess([NotNull] Type type, bool expectFail, [NotNull, InstantHandle] TryCtor tryCtor)
        {
            Assert.AreEqual(!expectFail, tryCtor(out object instance, out Exception ex));
            if (expectFail)
            {
                Assert.IsNull(instance);
                Assert.IsNotNull(ex);
            }
            else
            {
                Assert.IsNotNull(instance);
                Assert.AreEqual(Activator.CreateInstance(type), instance);
            }
        }

        public static void TryNewParameterLess([NotNull, InstantHandle] TryCtor tryCtor, [NotNull, InstantHandle] Func<object> expectedObject)
        {
            Assert.IsTrue(tryCtor(out object instance, out Exception _));
            Assert.IsNotNull(instance);
            Assert.AreEqual(expectedObject(), instance);
        }

        #endregion

        #region New(params)/TryNew(params)

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateNotDefaultConstructorNullParamsTestCases
        {
            [UsedImplicitly]
            get
            {
                yield return new TestCaseData(typeof(int), null);
                yield return new TestCaseData(typeof(TestStruct), null);
                yield return new TestCaseData(typeof(DefaultConstructor), null);
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<int>), null);
                yield return new TestCaseData(typeof(ParamsOnlyConstructor), null);
                yield return new TestCaseData(typeof(IntParamsOnlyConstructor), null);
                yield return new TestCaseData(typeof(NullableIntParamsOnlyConstructor), null);
                yield return new TestCaseData(typeof(DefaultInheritedDefaultConstructor), null);
                yield return new TestCaseData(typeof(DefaultInheritedNoDefaultConstructor), null);
                yield return new TestCaseData(typeof(DefaultInheritedFromAbstractClass), null);
                yield return new TestCaseData(typeof(List<int>), null);
                yield return new TestCaseData(typeof(Dictionary<int, string>), null);
            }
        }

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateNotDefaultConstructorNotNullParamsTestCases
        {
            [UsedImplicitly]
            get
            {
                yield return new TestCaseData(typeof(int), new object[] { });
                yield return new TestCaseData(typeof(TestStruct), new object[] { });
                yield return new TestCaseData(typeof(DefaultConstructor), new object[] { });
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<int>), new object[] { });
                yield return new TestCaseData(typeof(ParamsOnlyConstructor), new object[] { });
                yield return new TestCaseData(typeof(IntParamsOnlyConstructor), new object[] { });
                yield return new TestCaseData(typeof(NullableIntParamsOnlyConstructor), new object[] { });
                yield return new TestCaseData(typeof(DefaultInheritedDefaultConstructor), new object[] { });
                yield return new TestCaseData(typeof(DefaultInheritedNoDefaultConstructor), new object[] { });
                yield return new TestCaseData(typeof(DefaultInheritedFromAbstractClass), new object[] { });
                yield return new TestCaseData(typeof(List<int>), new object[] { });
                yield return new TestCaseData(typeof(Dictionary<int, string>), new object[] { });

                yield return new TestCaseData(typeof(ParameterConstructorStruct), new object[] { 12 });
                yield return new TestCaseData(typeof(NoDefaultConstructor), new object[] { 12 });
                yield return new TestCaseData(typeof(MultiParametersConstructor), new object[] { 12, 42.5f });
                yield return new TestCaseData(typeof(MultipleConstructors), new object[] { 12 });
                yield return new TestCaseData(typeof(MultipleConstructors), new object[] { 12, 42.5f });
                yield return new TestCaseData(typeof(TemplateNoDefaultConstructor<int>), new object[] { 12 });
                yield return new TestCaseData(typeof(ParamsOnlyConstructor), new object[] { 12 });
                yield return new TestCaseData(typeof(ParamsOnlyConstructor), new object[] { 12, 15.4f });
                yield return new TestCaseData(typeof(IntParamsOnlyConstructor), new object[] { 12 });
                yield return new TestCaseData(typeof(IntParamsOnlyConstructor), new object[] { 12, 15 });
                yield return new TestCaseData(typeof(NullableIntParamsOnlyConstructor), new object[] { 12, null, 25 });
                yield return new TestCaseData(typeof(ParamsConstructor), new object[] { 12 });
                yield return new TestCaseData(typeof(ParamsConstructor), new object[] { 12, 15.4f });
                yield return new TestCaseData(typeof(NoDefaultInheritedDefaultConstructor), new object[] { 12 });
                yield return new TestCaseData(typeof(NoDefaultInheritedNoDefaultConstructor), new object[] { 42 });
                yield return new TestCaseData(typeof(NoDefaultInheritedFromAbstractClass), new object[] { 25 });
                yield return new TestCaseData(typeof(int[]), new object[] { 5 });
                yield return new TestCaseData(typeof(List<int>), new object[] { 2 });
                yield return new TestCaseData(typeof(List<int>), new object[] { Enumerable.Range(0, 5) });
                yield return new TestCaseData(typeof(Dictionary<int, string>), new object[] { 3 });
            }
        }

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateNotDefaultConstructorTestCases
        {
            [UsedImplicitly]
            get
            {
                foreach (TestCaseData testCase in CreateNotDefaultConstructorNullParamsTestCases)
                    yield return testCase;
                foreach (TestCaseData testCase in CreateNotDefaultConstructorNotNullParamsTestCases)
                    yield return testCase;
            }
        }

        public delegate object ArgsCtor(params object[] args);

        public static void NewWithParameters([NotNull] Type type, [NotNull, InstantHandle] ArgsCtor ctor, [CanBeNull, ItemCanBeNull] params object[] args)
        {
            object instance = ctor(args);
            Assert.IsNotNull(instance);
            Assert.AreEqual(Activator.CreateInstance(type, args), instance);
        }

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateNotDefaultConstructorNoThrowNullParamsTestCases
        {
            [UsedImplicitly]
            get
            {
                yield return new TestCaseData(typeof(int), false, null);
                yield return new TestCaseData(typeof(TestStruct), false, null);
                yield return new TestCaseData(typeof(DefaultConstructor), false, null);
                yield return new TestCaseData(typeof(MultipleConstructors), false, null);
                yield return new TestCaseData(typeof(TemplateStruct<double>), false, null);
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<int>), false, null);
                yield return new TestCaseData(typeof(ParamsOnlyConstructor), false, null);
                yield return new TestCaseData(typeof(IntParamsOnlyConstructor), false, null);
                yield return new TestCaseData(typeof(NullableIntParamsOnlyConstructor), false, null);
                yield return new TestCaseData(typeof(DefaultInheritedDefaultConstructor), false, null);
                yield return new TestCaseData(typeof(DefaultInheritedNoDefaultConstructor), false, null);
                yield return new TestCaseData(typeof(DefaultInheritedFromAbstractClass), false, null);
                yield return new TestCaseData(typeof(List<int>), false, null);
                yield return new TestCaseData(typeof(Dictionary<int, string>), false, null);

                yield return new TestCaseData(typeof(NoDefaultConstructor), true, null);
                yield return new TestCaseData(typeof(NotAccessibleDefaultConstructor), true, null);
                yield return new TestCaseData(typeof(AbstractDefaultConstructor), true, null);
                yield return new TestCaseData(typeof(StaticClass), true, null);
                yield return new TestCaseData(typeof(TemplateStruct<>), true, null);
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<>), true, null);
                // ReSharper disable once PossibleMistakenCallToGetType.2
                yield return new TestCaseData(typeof(DefaultConstructor).GetType(), true, null);
                yield return new TestCaseData(typeof(DefaultConstructorThrows), true, null);
                yield return new TestCaseData(typeof(int[]), true, null);
            }
        }

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateNotDefaultConstructorNoThrowNotNullParamsTestCases
        {
            [UsedImplicitly]
            get
            {
                yield return new TestCaseData(typeof(int), false, new object[] { });
                yield return new TestCaseData(typeof(TestStruct), false, new object[] { });
                yield return new TestCaseData(typeof(DefaultConstructor), false, new object[] { });
                yield return new TestCaseData(typeof(MultipleConstructors), false, new object[] { });
                yield return new TestCaseData(typeof(MultipleConstructors), false, new object[] { 12, 12.5f });
                yield return new TestCaseData(typeof(TemplateStruct<double>), false, new object[] { });
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<int>), false, new object[] { });
                yield return new TestCaseData(typeof(DefaultConstructorThrows), false, new object[] { 45, 51.0f });
                yield return new TestCaseData(typeof(ParamsOnlyConstructor), false, new object[] { });
                yield return new TestCaseData(typeof(ParamsOnlyConstructor), false, new object[] { 12, 45.5f });
                yield return new TestCaseData(typeof(IntParamsOnlyConstructor), false, new object[] { });
                yield return new TestCaseData(typeof(IntParamsOnlyConstructor), false, new object[] { 45, 54 });
                yield return new TestCaseData(typeof(NullableIntParamsOnlyConstructor), false, new object[] { });
                yield return new TestCaseData(typeof(NullableIntParamsOnlyConstructor), false, new object[] { 12, null, 25 });
                yield return new TestCaseData(typeof(DefaultInheritedDefaultConstructor), false, new object[] { });
                yield return new TestCaseData(typeof(DefaultInheritedNoDefaultConstructor), false, new object[] { });
                yield return new TestCaseData(typeof(DefaultInheritedFromAbstractClass), false, new object[] { });
                yield return new TestCaseData(typeof(NoDefaultInheritedDefaultConstructor), false, new object[] { 12 });
                yield return new TestCaseData(typeof(NoDefaultInheritedNoDefaultConstructor), false, new object[] { 42 });
                yield return new TestCaseData(typeof(NoDefaultInheritedFromAbstractClass), false, new object[] { 25 });
                yield return new TestCaseData(typeof(int[]), false, new object[] { 5 });
                yield return new TestCaseData(typeof(List<int>), false, new object[] { });
                yield return new TestCaseData(typeof(List<int>), false, new object[] { 2 });
                yield return new TestCaseData(typeof(List<int>), false, new object[] { Enumerable.Range(0, 5) });
                yield return new TestCaseData(typeof(Dictionary<int, string>), false, new object[] { });
                yield return new TestCaseData(typeof(Dictionary<int, string>), false, new object[] { 3 });

                yield return new TestCaseData(typeof(int), true, new object[] { 12 });
                yield return new TestCaseData(typeof(TestStruct), true, new object[] { 12 });
                yield return new TestCaseData(typeof(DefaultConstructor), true, new object[] { 12 });
                yield return new TestCaseData(typeof(MultipleConstructors), true, new object[] { 12.5f, 12 });
                yield return new TestCaseData(typeof(TemplateStruct<double>), true, new object[] { 25 });
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<int>), true, new object[] { 25 });
                yield return new TestCaseData(typeof(NoDefaultConstructor), true, new object[] { });
                yield return new TestCaseData(typeof(NotAccessibleDefaultConstructor), true, new object[] { });
                yield return new TestCaseData(typeof(AbstractDefaultConstructor), true, new object[] { });
                yield return new TestCaseData(typeof(StaticClass), true, new object[] { });
                yield return new TestCaseData(typeof(TemplateStruct<>), true, new object[] { });
                yield return new TestCaseData(typeof(TemplateDefaultConstructor<>), true, new object[] { });
                yield return new TestCaseData(typeof(DefaultInheritedDefaultConstructor), true, new object[] { 45 });
                yield return new TestCaseData(typeof(DefaultInheritedNoDefaultConstructor), true, new object[] { 51 });
                yield return new TestCaseData(typeof(DefaultInheritedFromAbstractClass), true, new object[] { 72 });
                yield return new TestCaseData(typeof(NoDefaultInheritedDefaultConstructor), true, new object[] { 45, 35 });
                yield return new TestCaseData(typeof(NoDefaultInheritedNoDefaultConstructor), true, new object[] { 51, 25 });
                yield return new TestCaseData(typeof(NoDefaultInheritedFromAbstractClass), true, new object[] { 72, 15 });
                // ReSharper disable once PossibleMistakenCallToGetType.2
                yield return new TestCaseData(typeof(DefaultConstructor).GetType(), true, new object[] { });
                yield return new TestCaseData(typeof(DefaultConstructorThrows), true, new object[] { });
                yield return new TestCaseData(typeof(DefaultConstructorThrows), true, new object[] { 12 });
                yield return new TestCaseData(typeof(int[]), true, new object[] { });
            }
        }

        [NotNull, ItemNotNull]
        public static IEnumerable<TestCaseData> CreateNotDefaultConstructorNoThrowTestCases
        {
            [UsedImplicitly]
            get
            {
                foreach (TestCaseData testCase in CreateNotDefaultConstructorNoThrowNullParamsTestCases)
                    yield return testCase;
                foreach (TestCaseData testCase in CreateNotDefaultConstructorNoThrowNotNullParamsTestCases)
                    yield return testCase;
            }
        }

        public delegate bool TryArgsCtor(out object instance, out Exception exception, params object[] args);

        public static void TryNewWithParameters([NotNull] Type type, bool expectFail, [NotNull, InstantHandle] TryArgsCtor tryCtor, [CanBeNull, ItemCanBeNull] params object[] args)
        {
            Assert.AreEqual(!expectFail, tryCtor(out object instance, out Exception ex, args));
            if (expectFail)
            {
                Assert.IsNull(instance);
                Assert.IsNotNull(ex);
            }
            else
            {
                Assert.IsNotNull(instance);
                Assert.AreEqual(Activator.CreateInstance(type, args), instance);
            }
        }

        #endregion
    }
}