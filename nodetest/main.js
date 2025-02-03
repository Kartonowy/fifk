export function gcd_rec(a, b) {
  return b ? gcd_rec(b, a % b) : Math.abs(a);
}
export const qsort = ([pivot, ...others]) => 
  pivot === void 0 ? [] : [
    ...qsort(others.filter(n => n < pivot)),
    pivot,
    ...qsort(others.filter(n => n >= pivot))
  ];
