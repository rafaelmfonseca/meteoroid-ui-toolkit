using System;
using System.Linq;
using NUnit.Framework;
using Meteoroid.Graphics.Metadata;

namespace Meteoroid.Graphics.Tests
{
    [TestFixture]
    public class WidgetTest
    {
        internal class CustomWidget : Widget
        {
            public int StateChangedCount { get; set; }
            public int ParentChangedCount { get; set; }

            private State<string> _text;
            public State<string> Text { get => _text; set => RegistryPropertyState(nameof(Text), ref _text, value); }

            public override void OnStateChanged(StateChangedEvent e) => StateChangedCount++;
            public override void OnParentChanged(ElementParentChangedEvent e) => ParentChangedCount++;
        }

        [Test]
        public void TestWidgetStateChangedEventShouldAlwaysBeTriggeredOnce()
        {
            var state = new State<string>("initial text");

            var widget = new CustomWidget() { Text = state };

            Assert.That(widget.StateChangedCount, Is.EqualTo(1));
        }

        [Test]
        public void TestWidgetStateChangedEvent()
        {
            var state = new State<string>("initial text");

            var widget = new CustomWidget() { Text = state };

            Assert.That(widget.StateChangedCount, Is.EqualTo(1));

            state.Value = "text changed 1";
            state.Value = "text changed 2";

            Assert.That(widget.StateChangedCount, Is.EqualTo(3));
        }

        [Test]
        public void TestWidgetStateChangedEventWithDisabledState()
        {
            var widget = new CustomWidget() { Text = "initial text" };

            Assert.That(widget.StateChangedCount, Is.EqualTo(1));

            Assert.Throws<InvalidOperationException>(() => widget.Text.Value = "text changed");

            Assert.That(widget.StateChangedCount, Is.EqualTo(1));

            Assert.DoesNotThrow(() => widget.Text = "text changed");

            Assert.That(widget.StateChangedCount, Is.EqualTo(2));
        }

        [Test]
        public void TestWidgetShouldCreateElement()
        {
            var widget = new CustomWidget() { Text = "initial text" };

            Assert.NotNull(widget.Element);
        }

        [Test]
        public void TestWidgetShouldChangeChildrenParent()
        {
            var children = new IWidget[]
            {
                new CustomWidget(),
                new CustomWidget(),
                new CustomWidget(),
            };

            var widget = new CustomWidget()
            {
                Text = "initial text",
                Children = children
            };

            Assert.IsTrue(children.All(c => ReferenceEquals(c.Element.transform.parent, widget.Element.transform)));
        }

        [Test]
        public void TestWidgetShouldChangeNewChildrenParent()
        {
            var widget = new CustomWidget()
            {
                Text = "initial text",
                Children = new IWidget[] { }
            };

            var children = new IWidget[]
            {
                new CustomWidget(),
                new CustomWidget(),
                new CustomWidget(),
            };

            widget.Children = children;

            Assert.IsTrue(children.All(c => ReferenceEquals(c.Element.transform.parent, widget.Element.transform)));

            children = new IWidget[]
            {
                new CustomWidget(),
                new CustomWidget(),
                new CustomWidget(),
            };

            widget.Children = children;

            Assert.IsTrue(children.All(c => ReferenceEquals(c.Element.transform.parent, widget.Element.transform)));
        }

        [Test]
        public void TestWidgetShouldUnsubscribeFromOldState()
        {
            var state = new State<string>("initial text");

            var widget = new CustomWidget() { Text = state };

            widget.Text = "text changed";

            state.Value = "another text 1";
            state.Value = "another text 2";
            state.Value = "another text 3";
            state.Value = "another text 4";

            Assert.That(widget.StateChangedCount, Is.EqualTo(2));
        }

        [Test]
        public void TestWidgetShouldTriggerParentChangedEventOfChildren()
        {
            var children = new IWidget[]
            {
                new CustomWidget(),
                new CustomWidget(),
                new CustomWidget(),
            };

            Assert.IsTrue(children.OfType<CustomWidget>().All(c => c.ParentChangedCount == 0));

            var widget = new CustomWidget()
            {
                Text = "initial text",
                Children = children
            };

            Assert.IsTrue(children.OfType<CustomWidget>().All(c => c.ParentChangedCount == 1));
        }

        [Test]
        public void TestWidgetShouldNotTriggerParentChangedIfSameParent()
        {
            var children = new IWidget[]
            {
                new CustomWidget(),
                new CustomWidget(),
                new CustomWidget(),
            };

            var widget = new CustomWidget()
            {
                Text = "initial text"
            };

            widget.Children = new IWidget[] { children[0], children[1], children[2] };

            Assert.IsTrue(children.OfType<CustomWidget>().All(c => c.ParentChangedCount == 1));

            widget.Children = new IWidget[] { children[0], children[1], children[2] };

            Assert.IsTrue(children.OfType<CustomWidget>().All(c => c.ParentChangedCount == 1));
        }
    }
}
