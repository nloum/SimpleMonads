using System;

namespace SimpleMonads
{
    public class Either<T1, T2> : IEither<T1, T2>
    {
        public Either(T1 item1)
        {
            Item1 = item1.ToMaybe();
        }

        public Either(T2 item2)
        {
            Item2 = item2.ToMaybe();
        }

        public IMaybe<T1> Item1 { get; } = Utility.Nothing<T1>();
        public IMaybe<T2> Item2 { get; } = Utility.Nothing<T2>();

        public IEither<T1, T2, T3> Or<T3>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4> Or<T3, T4>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5> Or<T3, T4, T5>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6> Or<T3, T4, T5, T6>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7> Or<T3, T4, T5, T6, T7>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8> Or<T3, T4, T5, T6, T7, T8>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9> Or<T3, T4, T5, T6, T7, T8, T9>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Or<T3, T4, T5, T6, T7, T8, T9, T10>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Or<T3, T4, T5, T6, T7, T8, T9, T10, T11>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
            Or<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Or<T3, T4, T5, T6, T7, T8, T9, T10, T11,
            T12, T13>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Or<T3, T4, T5, T6, T7, T8, T9, T10,
            T11, T12, T13, T14>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Or<T3, T4, T5, T6, T7, T8, T9,
            T10, T11, T12, T13, T14, T15>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }

        public IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Or<T3, T4, T5, T6, T7, T8,
            T9, T10, T11, T12, T13, T14, T15, T16>()
        {
            if (Item1.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Item1.Value);
            }

            if (Item2.HasValue)
            {
                return new Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Item2.Value);
            }

            throw new System.InvalidOperationException("The either has no values");
        }
    }
}