namespace SimpleMonads {
public interface IEither<out T1, out T2, out T3> 
{
IMaybe<T1> Item1 { get; }
IMaybe<T2> Item2 { get; }
IMaybe<T3> Item3 { get; }
object Value { get; }
IEither<T1, T2, T3, T4> Or<T4>();
IEither<T1, T2, T3, T4, T5> Or<T4, T5>();
IEither<T1, T2, T3, T4, T5, T6> Or<T4, T5, T6>();
IEither<T1, T2, T3, T4, T5, T6, T7> Or<T4, T5, T6, T7>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8> Or<T4, T5, T6, T7, T8>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9> Or<T4, T5, T6, T7, T8, T9>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Or<T4, T5, T6, T7, T8, T9, T10>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Or<T4, T5, T6, T7, T8, T9, T10, T11>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Or<T4, T5, T6, T7, T8, T9, T10, T11, T12>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Or<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Or<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Or<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
IEither<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Or<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
public interface ICast<out TBase> : IEither<T1, T2, T3> {
new TBase Value { get; }
}
}
}
