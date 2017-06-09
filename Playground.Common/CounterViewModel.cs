using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using System;

namespace Playground.Common
{
    public class CounterViewModel
    {
        readonly ReactiveProperty<string> title = new ReactiveProperty<string>();
        readonly Counter counter = new Counter();

        public ReadOnlyReactiveProperty<string> Title { get; }
        public ReadOnlyReactiveProperty<string> CounterValue { get; }
        public ReactiveCommand Increment { get; } = new ReactiveCommand();
        public ReactiveCommand Decrement { get; } = new ReactiveCommand();
        public ReactiveCommand Reset { get; } = new ReactiveCommand();

        public CounterViewModel()
        {
            title.Value = "last value: ---";
            Title = title.ToReadOnlyReactiveProperty();
            CounterValue = counter
                .ObserveProperty(x => x.Value)
                .Select(x => x.ToString())
                .ToReadOnlyReactiveProperty();
            Increment.Subscribe(_ => counter.Increment());
            Decrement.Subscribe(_ => counter.Decrement());
            Reset.Subscribe(_ => { title.Value = $"last value: {CounterValue.Value}"; counter.Reset(); });
        }
    }
}
