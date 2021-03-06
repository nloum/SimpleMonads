using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;

namespace SimpleMonads
{
    [DataContract]
    public class Maybe<T> : IMaybe<T>
    {
        private static readonly IMaybe<T> _nothing = new Maybe<T>();

        private readonly Action _throwOnNothingAccessed;

        private Maybe()
        {
            _throwOnNothingAccessed = () => throw new MemberAccessException("Cannot access value of a Nothing");
            HasValue = false;
        }

        internal Maybe(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            _throwOnNothingAccessed = () => throw new NotImplementedException("This line should never be reached because a value was specified");
            HasValue = true;
            Value = value;
        }

        private Maybe(Action throwOnNothingAccessed)
        {
            _throwOnNothingAccessed = throwOnNothingAccessed;
            HasValue = false;
        }

        [DataMember] public bool HasValue { get; set; }

        public T Value
        {
            get
            {
                if (!HasValue) _throwOnNothingAccessed();
                return ValueOrDefault!;
            }
            set => ValueOrDefault = value;
        }

        [DataMember] public T? ValueOrDefault { get; set; }

        public object ObjectValue
        {
            get
            {
                if (HasValue)
                    return Value!;
                else
                {
                    _throwOnNothingAccessed();
                    throw new NotImplementedException();
                }
            }
        }

        public object? ObjectValueOrDefault => ValueOrDefault;

        public TMonad2 Bind<TMonad2, TElement2>(Func<T, TMonad2> f) where TMonad2 : IMonad<TElement2>
        {
            return f(Value);
        }

        public static IMaybe<T> Nothing()
        {
            return _nothing;
        }

        public static IMaybe<T> Nothing(Action throwOnNothingAccessed)
        {
            return new Maybe<T>(throwOnNothingAccessed);
        }

        protected bool Equals(IMaybe<T> other)
        {
            if (!HasValue && !other.HasValue) {
                return true;
            }
            
            if (HasValue && other.HasValue) {
                return EqualityComparer<T>.Default.Equals(Value, other.Value);
            }
            
            // At this point one of the maybes has a value and the other doesn't,
            // so return false without accessing the .Value of either (because accessing
            // the .Value will throw an exception).
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((IMaybe<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(Value) * 397) ^ HasValue.GetHashCode();
            }
        }

        public override string ToString()
        {
            return HasValue ? $"Some({Value})" : "None";
        }

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
        
        public static implicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }
    }

    public static class Maybe
    {
        public static IMaybe<T> Cast<T>(this IMaybe maybe)
        {
            if (maybe.HasValue)
            {
                return new Maybe<T>((T) maybe.ObjectValue);
            }
            return Maybe<T>.Nothing();
        }
        
        public static IMaybe<T> OfType<T>(this IMaybe maybe)
        {
            if (maybe.HasValue && maybe.ObjectValue is T t)
            {
                return new Maybe<T>(t);
            }
            
            return Maybe<T>.Nothing();
        }
    
        public static IMaybe<T> WithErrorMessage<T>(this IMaybe<T> maybe, Action errorMessage)
        {
            if (maybe.HasValue)
                return maybe;
            return Maybe<T>.Nothing(errorMessage);
        }

        public static IMaybe<TElement> ToMaybe<TElement>(this TElement element)
        {
            if (element == null)
                return Maybe<TElement>.Nothing(() =>
                    throw new IndexOutOfRangeException("The element this maybe was created from was null"));
            return new Maybe<TElement>(element);
        }

        public static IMaybe<TElement> ToMaybe<TElement>(this TElement element, Action throwOnNothingAccessed)
        {
            if (element == null)
                return Maybe<TElement>.Nothing(throwOnNothingAccessed);
            return new Maybe<TElement>(element);
        }

        public static IMaybe<TNumber3> SelectMany<TNumber1, TNumber2, TNumber3>(this IMaybe<TNumber1> a,
            Func<TNumber1, IMaybe<TNumber2>> func,
            Func<TNumber1, TNumber2, TNumber3>
                select)
        {
            return a.SelectMany(func, select, ToMaybe);
        }

        public static IMaybe<T2> Select<T1, T2>(this IMaybe<T1> source, Func<T1, T2> selector)
        {
            if (source.HasValue)
                return selector(source.Value).ToMaybe();
            return Maybe<T2>.Nothing(() =>
            {
                var tmp = source.Value;
            });
        }

        public static IMaybe<T2> Select<T1, T2>(this IMaybe<T1> source, Func<T1, T2> selector,
            Action throwOnNothingAccessed)
        {
            if (source.HasValue)
                return selector(source.Value).ToMaybe();
            return Maybe<T2>.Nothing(throwOnNothingAccessed);
        }

        public static IMaybe<T2> SelectMany<T1, T2>(this IMaybe<T1> source, Func<T1, IMaybe<T2>> selector)
        {
            if (source.HasValue)
                return selector(source.Value);
            return Maybe<T2>.Nothing(() =>
            {
                var tmp = source.Value;
            });
        }

        public static IMaybe<T2> SelectMany<T1, T2>(this IMaybe<T1> source, Func<T1, IMaybe<T2>> selector,
            Action throwOnNothingAccessed)
        {
            if (source.HasValue)
                return selector(source.Value);
            return Maybe<T2>.Nothing(throwOnNothingAccessed);
        }

        public static T Otherwise<T>(this IMaybe<T> source, Func<T> fallback)
        {
            if (source.HasValue)
                return source.Value;
            return fallback();
        }

        public static T Otherwise<T>(this IMaybe<T> source, T fallback)
        {
            if (source.HasValue)
                return source.Value;
            return fallback;
        }

        public static IEnumerable<T> ToEnumerable<T>(this IMaybe<T> source)
        {
            var result = source.Select(value => ImmutableList<T>.Empty.Add(value))
                .Otherwise(() => ImmutableList<T>.Empty);
            return result;
        }

        public static IMaybe<T> IfHasValue<T>(this IMaybe<T> maybe, Action<T> action)
        {
            if (maybe.HasValue) action(maybe.Value);
            return maybe;
        }

        public static IMaybe<IReadOnlyList<T>> AllOrNothing<T>(this IEnumerable<IMaybe<T>> maybes)
        {
            var all = new List<T>();
            foreach (var maybe in maybes)
            {
                if (!maybe.HasValue) return Maybe<IReadOnlyList<T>>.Nothing();

                all.Add(maybe.Value);
            }

            return all.ToMaybe();
        }

        public static IMaybe<IReadOnlyList<T>> AllOrNothing<T>(this IEnumerable<IMaybe<T>> maybes,
            Action throwOnNothingAccessed)
        {
            var all = new List<T>();
            foreach (var maybe in maybes)
            {
                if (!maybe.HasValue) return Maybe<IReadOnlyList<T>>.Nothing(throwOnNothingAccessed);

                all.Add(maybe.Value);
            }

            return all.ToMaybe();
        }

        public static IEnumerable<T> WhereHasValue<T>(this IEnumerable<IMaybe<T>> maybes)
        {
            return maybes.Where(m => m.HasValue).Select(m => m.Value);
        }
    }
}
