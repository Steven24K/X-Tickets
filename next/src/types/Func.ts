type Sum<a, b> = { kind: 'l', v: a } | { kind: 'r', v: b }

export type Either<a, b> = Sum<a, b>
export const EitherA = <a, b>(_v: a): Either<a, b> => ({ kind: 'l', v: _v })
export const EitherB = <a, b>(_v: b): Either<a, b> => ({ kind: 'r', v: _v })

export type Option<a> = Sum<a, false>
export const Some = <a>(_v: a): Option<a> => ({ kind: 'l', v: _v })
export const None = <a>(): Option<a> => ({ kind: 'r', v: false })

export type Product<a, b> = [a, b]
export const Tuple = <a, b>(_a: a, _b: b): Product<a, b> => ([_a, _b])