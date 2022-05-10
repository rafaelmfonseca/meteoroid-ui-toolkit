using System;
using UnityEngine;
using UnityEngine.Events;
using NUnit.Framework;
using Meteoroid.Graphics.Metadata;
using Meteoroid.Graphics.Metadata.Generic;

namespace Meteoroid.Graphics.Tests
{
    [TestFixture]
    public class StateTest
    {
        [Test]
        public void TestConstructorUsedAsDefaultValueWithValueType()
        {
            Assert.That(new State<Vector2>().Value, Is.EqualTo(Vector2.zero));
        }

        [Test]
        public void TestConstructorUsedAsDefaultValueWithReferenceType()
        {
            Assert.That(new State<Component>().Value, Is.EqualTo(null));
        }

        [Test]
        public void TestConstructorUsedAsInitialValue()
        {
            Assert.That(new State<Vector2>(Vector2.one).Value, Is.EqualTo(Vector2.one));
        }

        [Test]
        public void TestChangeStateValueWithNewValue()
        {
            const string initialValue = "initial value";
            const string expectedValue = "expected value";

            var state = new State<string>(initialValue);

            state.Value = expectedValue;

            Assert.That(state.Value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TestStateValueType()
        {
            const string initialValue = "initial value";

            var state = new State<string>(initialValue);

            Assert.That(state.Value, Is.TypeOf<string>());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestStateSetValue(bool value)
        {
            var state = new State<bool> { Value = value };

            Assert.That(state.Value, Is.EqualTo(value));
        }

        [Test]
        public void TestStateValueChangedEventRunImmediately()
        {
            var oldValue = 0;
            var newValue = 0;

            var state = new State<int>(10);

            state.AddListener(delegate (ValueChangedEvent<int> evt)
            {
                oldValue = evt.OldValue;
                newValue = evt.NewValue;
            });

            state.Value = 20;

            Assert.That(oldValue, Is.EqualTo(10));
            Assert.That(newValue, Is.EqualTo(20));

            state.Value = 30;

            Assert.That(oldValue, Is.EqualTo(20));
            Assert.That(newValue, Is.EqualTo(30));
        }

        [Test]
        public void TestConstructorUsedForDisabledState()
        {
            int changedCount = 0;

            var state = new State<int>(10, true);

            Assert.Throws<InvalidOperationException>(() => state.AddListener((evt) => changedCount++));
            Assert.Throws<InvalidOperationException>(() => state.Value = 20);

            Assert.That(state.Value, Is.EqualTo(10));
            Assert.That(changedCount, Is.EqualTo(0));

            state.Disabled = false;

            Assert.DoesNotThrow(() => state.AddListener((evt) => changedCount++));
            Assert.DoesNotThrow(() => state.Value = 30);

            Assert.That(state.Value, Is.EqualTo(30));
            Assert.That(changedCount, Is.EqualTo(1));
        }

        [Test]
        public void TestStateDisabledAfterCreated()
        {
            int changedCount = 0;

            var state = new State<int>(10);

            state.AddListener((evt) => changedCount++);
            state.Value = 20;

            state.Disabled = true;

            Assert.Throws<InvalidOperationException>(() => state.Value = 30);

            Assert.That(state.Value, Is.EqualTo(20));
            Assert.That(changedCount, Is.EqualTo(1));
        }

        [Test]
        public void TestStateEventsRemoved()
        {
            int changedCount = 0;

            var state = new State<int>(10);

            state.AddListener((evt) => changedCount++);
            state.Value = 20;

            Assert.That(changedCount, Is.EqualTo(1));

            state.RemoveAllListeners();
            state.Value = 30;

            Assert.That(changedCount, Is.EqualTo(1));
        }

        [Test]
        public void TestStateEventsRunImmediatelyThenRemovedAll()
        {
            int changedCount = 0;

            object state = new State<int>(10);

            (state as IState).AddListener((evt) => changedCount++);
            (state as IState<int>).AddListener((evt) => changedCount++);

            (state as IState).Value = 20;
            Assert.That(changedCount, Is.EqualTo(2));

            (state as IState<int>).Value = 30;
            Assert.That(changedCount, Is.EqualTo(4));

            (state as IState).RemoveAllListeners();

            (state as IState).Value = 40;
            Assert.That(changedCount, Is.EqualTo(4));
        }

        [Test]
        public void TestStateEventEachRemoved()
        {
            int changedCount = 0;

            object state = new State<int>(10);

            UnityAction<ValueChangedEvent> firstCall = (evt) => changedCount++;
            UnityAction<ValueChangedEvent<int>> secondCall = (evt) => changedCount++;

            (state as IState).AddListener(firstCall);
            (state as IState<int>).AddListener(secondCall);

            (state as IState).Value = 20;
            Assert.That(changedCount, Is.EqualTo(2));

            (state as IState).RemoveListener(firstCall);

            (state as IState).Value = 30;
            Assert.That(changedCount, Is.EqualTo(3));

            (state as IState<int>).RemoveListener(secondCall);

            (state as IState).Value = 40;
            Assert.That(changedCount, Is.EqualTo(3));
        }

        [Test]
        public void TestStateShouldNotTriggerEventsWhenSameValue()
        {
            int changedCount = 0;

            var state = new State<int>(10);

            (state as IState).AddListener((evt) => changedCount++);
            (state as IState<int>).AddListener((evt) => changedCount++);

            (state as IState).Value = 10;

            Assert.That(changedCount, Is.EqualTo(0));
        }
    }
}